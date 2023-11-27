using BussinessObject.Models;
using Microsoft.AspNetCore.Mvc;

namespace SEP_BackEndCodeApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment= webHostEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> UploadFiles(List<IFormFile> files,int classId)
        {
            if(files.Count == 0)
                return NotFound();
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");

            foreach (var file in files)
            {
                string fileName = file.FileName;
                string filePath = Path.Combine(directoryPath, file.FileName);
                using (var stream = new FileStream(filePath,FileMode.Create))
                {
                   await file.CopyToAsync(stream);
                }
                SaveFileInfoToDatabase(fileName, filePath, classId);
            }
            return Ok("Upload Successfull");
        }
        private void SaveFileInfoToDatabase(string fileName, string filePath,int classId)
        {
           
            using (var context = new DB_SEP490Context ()) 
            {
                var uploadedFile = new UploadedFile
                {
                    FileName = fileName,
                    FilePath = filePath,
                    ClassId= classId
                };

                context.UploadedFiles.Add(uploadedFile);
                context.SaveChanges();
            }
        }

        [HttpGet]
        public IActionResult GetUploadedFiles()
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");

            if (!Directory.Exists(directoryPath))
                return NotFound("Directory not found");

            var files = Directory.GetFiles(directoryPath)
                                 .Select(filePath => Path.GetFileName(filePath))
                                 .ToList();

            return Ok(files);
        }
        [HttpGet]
        public IActionResult GetAllFiles(int classId)
        {
            List<UploadedFile> uploadedFiles= new List<UploadedFile>();
            using (var context = new DB_SEP490Context())
            {
                uploadedFiles = context.UploadedFiles.Where(x=>x.ClassId == classId).ToList();
            }
            return Ok(uploadedFiles);
        }

        [HttpGet]
        public IActionResult GetFileByName(string fileName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            string filePath = Path.Combine(directoryPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);

       
            string contentType = "application/octet-stream";

            return File(fileBytes, contentType, fileName);
        }
        [HttpGet]
        public IActionResult GetFileByNameInWeb(string fileName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            string filePath = Path.Combine(directoryPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            var fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/pdf");
        }
        [HttpGet]
        public IActionResult GetImageByName(string fileName)
        {
            string directoryPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            string filePath = Path.Combine(directoryPath, fileName);

            if (!System.IO.File.Exists(filePath))
                return NotFound("File not found");

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "image/jpeg"); // Thay đổi kiểu content type nếu cần thiết
        }
    }
}
