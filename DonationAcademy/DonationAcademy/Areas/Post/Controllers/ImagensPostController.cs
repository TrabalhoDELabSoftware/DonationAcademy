using System.Security.Claims;
using DonationAcademy.Areas.Doador.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Hosting.Internal;

namespace DonationAcademy.Areas.Post.Controllers
{
    [Area("Post")]
    [Authorize]
    public class ImagensPostController : Controller
    {
        private readonly ConfigurationDoadorImagens _myConfig;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly FileManagerDoadorModel _fileManager;

        public ImagensPostController(
            IWebHostEnvironment hostingEnvironment,
            IOptions<ConfigurationDoadorImagens> myConfiguration,
            UserManager<IdentityUser> userManager,
            FileManagerDoadorModel fileManager)
        {
            _hostingEnvironment = hostingEnvironment;
            _myConfig = myConfiguration.Value;
            _userManager = userManager;
            _fileManager = fileManager;
        }

        public IActionResult Index()
        {
            return View();
        }


        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View(new FileManagerDoadorModel(_hostingEnvironment));
            }

            if (files.Count > 10)
            {
                ViewData["Erro"] = "Error: Quantidade de arquivos excedeu o limite";
                return View(new FileManagerDoadorModel(_hostingEnvironment));
            }

            long size = files.Sum(f => f.Length);

            var filePathsName = new List<string>();

            var userId = _userManager.GetUserId(User); // Obtém o ID do usuário atualmente logado
            var pastaUsuarios = userId; // Nome da pasta de imagens do usuário será o seu ID
            var folderPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensDoadores, pastaUsuarios);

            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath); // Cria a subpasta se ela não existir
            }

            foreach (var formFile in files)
            {
                if (formFile.FileName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                    formFile.FileName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                    formFile.FileName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                    formFile.FileName.EndsWith(".png", StringComparison.OrdinalIgnoreCase))
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(formFile.FileName); // Gera um nome único para o arquivo
                    var fileNameWithPath = Path.Combine(folderPath, fileName);
                    filePathsName.Add(fileNameWithPath);

                    using var stream = new FileStream(fileNameWithPath, FileMode.Create);
                    await formFile.CopyToAsync(stream);
                }
            }

            var user = await _userManager.GetUserAsync(User);
            var imageNamesClaim = new Claim("ImageNames", string.Join(",", filePathsName));
            await _userManager.AddClaimAsync(user, imageNamesClaim);

            var model = new FileManagerDoadorModel(_hostingEnvironment)
            {
                Arquivos = filePathsName,
                Mensagem = $"{filePathsName.Count} arquivos foram enviados ao servidor, com tamanho total de {size} bytes"
            };

            ViewData.Model = model;

            return View(model);
        }





        public async Task<IActionResult> GetImagens()
        {
            var model = new FileManagerDoadorModel(_hostingEnvironment);

            var user = await _userManager.GetUserAsync(User);
            var userId = user.Id;

            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensDoadores, userId);

            if (!Directory.Exists(userImagesPath))
            {
                Directory.CreateDirectory(userImagesPath);
            }

            var files = new DirectoryInfo(userImagesPath).GetFiles();

            model.PathImagesDoador = Path.Combine(_myConfig.NomePastaImagensDoadores, userId);

            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }

            model.FilesDoador = files;

            return View(model);
        }


        public async Task<IActionResult> DeleteFile(string fname)
        {
            var user = await _userManager.GetUserAsync(User);
            var userImagesPath = Path.Combine(_hostingEnvironment.WebRootPath, _myConfig.NomePastaImagensDoadores, user.Id);
            var fileNameWithPath = Path.Combine(userImagesPath, fname);

            if (System.IO.File.Exists(fileNameWithPath))
            {
                System.IO.File.Delete(fileNameWithPath);
                ViewData["Deletado"] = $"Arquivo {fname} deletado com sucesso";
            }
            else
            {
                ViewData["Erro"] = $"O arquivo {fname} não existe";
            }

            return View("Index");
        }



    }
}

