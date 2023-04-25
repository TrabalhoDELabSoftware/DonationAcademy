namespace DonationAcademy.Areas.Doador.Models
{
    public class FileManagerDoadorModel
    {
        private readonly IWebHostEnvironment _hostingEnvironment;

        public FileManagerDoadorModel(IWebHostEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }

        public FileInfo[] FilesDoador { get; set; }

        public IFormFile IFormFile { get; set; }

        public List<IFormFile> IFormFiles { get; set; }

        public string PathImagesDoador { get; set; }

        public List<string> Arquivos { get; internal set; }

        public string Mensagem { get; internal set; }

        public void ListFiles(string userId)
        {
            PathImagesDoador = Path.Combine(_hostingEnvironment.WebRootPath, "images/produtosDoacao", userId);
            if (Directory.Exists(PathImagesDoador))
            {
                DirectoryInfo directory = new DirectoryInfo(PathImagesDoador);
                FilesDoador = directory.GetFiles();
            }
        }

        public async Task<bool> SaveFiles(string userId)
        {
            bool success = false;
            try
            {
                if (IFormFiles != null && IFormFiles.Any())
                {
                    CreateDirectory(userId);
                    foreach (var formFile in IFormFiles)
                    {
                        if (formFile.Length > 0)
                        {
                            var filePath = Path.Combine(PathImagesDoador, formFile.FileName);
                            using (var stream = new FileStream(filePath, FileMode.Create))
                            {
                                await formFile.CopyToAsync(stream);
                            }
                        }
                    }
                    success = true;
                }
            }
            catch (Exception ex)
            {
                Mensagem = "Erro ao enviar os arquivos: " + ex.Message;
            }
            return success;
        }

        private void CreateDirectory(string userId)
        {
            string path = Path.Combine(_hostingEnvironment.WebRootPath, "images/produtosDoacao", userId);
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            PathImagesDoador = path;
        }
    }

}
