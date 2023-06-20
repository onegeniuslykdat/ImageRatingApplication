using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.IO.Compression;

namespace ImageRatingAPI.Services
{
    public class FileService
    {
        private readonly IWebHostEnvironment environment;
        private readonly IConfiguration config;
        private readonly string imagesFolder = "images";
        public FileService(IWebHostEnvironment _env, IConfiguration _config)
        {
            environment = _env;
            config = _config;
        }

        //public async Task<string> GetFileUrl(IFormFile file)
        //{
        //    //logger.LogInformation("Inside the {method} method. About to get url for file {fileName}", nameof(GetFileUrl), JsonConvert.SerializeObject(file.FileName));
        //    try
        //    {
        //        // Make sure Content Type is Picture or Pdf
        //        if (!((file.ContentType.Contains("image/jpeg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/jpg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/png", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/pdf", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase))))
        //        {
        //            //logger.LogInformation("Invalid file type for file {fileName}", JsonConvert.SerializeObject(file.FileName));

        //            return null;
        //        }
        //        // Get Upload folder path
        //        string uploads = Path.Combine(environment.WebRootPath, customerUploadFolder);

        //        if (!Directory.Exists(uploads))
        //        {
        //            Directory.CreateDirectory(uploads);
        //        }

        //        // Use a different name for file
        //        string newGuid = Guid.NewGuid().ToString().Split('-')[0];
        //        FileInfo fileInfo = new FileInfo(file.FileName);
        //        string fileExt = fileInfo.Extension; //'.' + file.FileName.Split('.')[1];
        //        string newName = newGuid + '_' + DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-f").Replace('-', '_') + fileExt;

        //        if (file.Length > 0)
        //        {
        //            string filePath = Path.Combine(uploads, newName);
        //            using (Stream fileStream = new FileStream(filePath, FileMode.Create))
        //            {
        //                await file.CopyToAsync(fileStream);
        //            }

        //            //logger.LogInformation("File {fileName} successfully stored", JsonConvert.SerializeObject(file.FileName));

        //            return filePath;
        //        }
        //        else
        //        {
        //            //logger.LogInformation("File {fileName} not found", JsonConvert.SerializeObject(file.FileName));

        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error occurred while getting the url for file {fileName}", JsonConvert.SerializeObject(file.FileName));

        //        return null;
        //    }
        //}

        //public async Task<string> ConvertFileToBase64String(IFormFile file)
        //{
        //    //logger.LogInformation("Inside the {method} method. About to convert file {fileName} to string", nameof(ConvertFileToBase64String), JsonConvert.SerializeObject(file.FileName));
        //    try
        //    {
        //        // Make sure Content Type is Picture or Pdf
        //        if (!((file.ContentType.Contains("image/jpeg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/jpg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/png", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/pdf", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase))))
        //        {
        //            //logger.LogInformation("Invalid file type for file {fileName}", JsonConvert.SerializeObject(file.FileName));

        //            return null;
        //        }

        //        // Setup
        //        string base64String;

        //        if (file.Length > 0)
        //        {
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                await file.CopyToAsync(stream);
        //                byte[] bytes = stream.ToArray();
        //                base64String = Convert.ToBase64String(bytes);

        //                stream.Dispose();
        //                stream.Close();
        //            }

        //            //logger.LogInformation("File {fileName} successfully converted to string", JsonConvert.SerializeObject(file.FileName));

        //            return base64String;
        //        }
        //        else
        //        {
        //            //logger.LogInformation("File {fileName} not found", JsonConvert.SerializeObject(file.FileName));

        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error occurred while converting file {fileName} to string", JsonConvert.SerializeObject(file.FileName));

        //        return null;
        //    }
        //}

        //public async Task<IFormFile> DecodeFileFromBase64String(string base64String, string ext)
        //{
        //    //logger.LogInformation("Inside the {method} method.", nameof(DecodeFileFromBase64String));
        //    try
        //    {
        //        // Setup
        //        IFormFile formFile;

        //        // Get download folder path
        //        string downloads = Path.Combine(environment.WebRootPath, customerDownloadFolder);

        //        if (!Directory.Exists(downloads))
        //        {
        //            Directory.CreateDirectory(downloads);
        //        }

        //        byte[] bytes = Convert.FromBase64String(base64String);
        //        string randfilename = $"retrievedFile_stream_{DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-f".Replace('-', '_'))}.{ext}";
        //        FileStream thisfile = new FileStream(downloads + $"/{randfilename}", FileMode.Create);

        //        using (thisfile)
        //        {
        //            await thisfile.WriteAsync(bytes, 0, bytes.Length);

        //            formFile = new FormFile(thisfile, 0, thisfile.Length, randfilename, randfilename)
        //            {
        //                //ContentType = ext.Equals("png", StringComparison.InvariantCultureIgnoreCase) ? "image/png"
        //                //    : ext.Equals("jpg", StringComparison.InvariantCultureIgnoreCase) ? "image/jpeg"
        //                //    : $"application/{ext}"
        //            };
        //        }

        //        //logger.LogInformation("Successfully converted string to file {fileName}", JsonConvert.SerializeObject(formFile.FileName));

        //        return formFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error ccurred while converting string to file");

        //        return null;
        //    }
        //}


        //public async Task<string> ConvertFilePathToBase64String(string filename, string ext = null)
        //{
        //    //logger.LogInformation("Inside the {method} method. About to convert file {fileName} to string", nameof(ConvertFilePathToBase64String), JsonConvert.SerializeObject(filename));
        //    try
        //    {
        //        //// Make sure Content Type is Picture or Pdf
        //        //if (!((file.ContentType.Contains("image/jpeg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/jpg", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("image/png", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/pdf", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase)) || (file.ContentType.Contains("application/vnd.openxmlformats-officedocument.wordprocessingml.document", StringComparison.InvariantCultureIgnoreCase))))
        //        //{
        //        //    logger.LogInformation("Invalid file type for file {fileName}", JsonConvert.SerializeObject(file.FileName));

        //        //    return null;
        //        //}

        //        // Setup
        //        string base64String;
        //        string fullpath;
        //        // Check where file is
        //        string checkpath = string.IsNullOrWhiteSpace(ext) ? $"{environment.WebRootPath}/{downloadCenterFolder}/{filename}" : $"{environment.WebRootPath}/{downloadCenterFolder}/{filename}.{ext}";
        //        if (File.Exists(checkpath))
        //        {
        //            fullpath = checkpath;
        //        }
        //        else
        //        {
        //            checkpath = string.IsNullOrWhiteSpace(ext) ? $"{environment.WebRootPath}/{customerDownloadFolder}/{filename}" : $"{environment.WebRootPath}/{customerDownloadFolder}/{filename}.{ext}";
        //            if (File.Exists(checkpath))
        //            {
        //                fullpath = checkpath;
        //            }
        //            else
        //            {
        //                checkpath = string.IsNullOrWhiteSpace(ext) ? $"{environment.WebRootPath}/{customerUploadFolder}/{filename}" : $"{environment.WebRootPath}/{customerUploadFolder}/{filename}.{ext}";
        //                fullpath = checkpath;
        //            }
        //        }

        //        byte[] bytes = await File.ReadAllBytesAsync(fullpath);

        //        if (bytes.Length > 0)
        //        {
        //            using (MemoryStream stream = new MemoryStream())
        //            {
        //                base64String = Convert.ToBase64String(bytes);

        //                stream.Dispose();
        //                stream.Close();
        //            }

        //            //logger.LogInformation("File {fileName} successfully converted to string", JsonConvert.SerializeObject(filename));

        //            return base64String;
        //        }
        //        else
        //        {
        //            //logger.LogInformation("File {fileName} not found", JsonConvert.SerializeObject(filename));

        //            return null;
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error occurred while converting file {fileName} to string", JsonConvert.SerializeObject(filename));

        //        return null;
        //    }
        //}

        //public async Task<string> GetZippedFile64String(List<Tuple<string, string>> filesToZip, string zipname) //Tuple<extension, fullpath>
        //{
        //    //logger.LogInformation("Inside the {method} method.", nameof(GetZippedFile64String));
        //    try
        //    {
        //        // Setup
        //        string base64String;
        //        ZipArchive zip;
        //        //// Get upload folder path
        //        //string uploads = Path.Combine(environment.WebRootPath, customerUploadFolder);

        //        //if (!Directory.Exists(uploads))
        //        //{
        //        //    Directory.CreateDirectory(uploads);
        //        //}
        //        // Get download folder path
        //        string downloads = Path.Combine(environment.WebRootPath, customerDownloadFolder);

        //        string fullzipname = $"{zipname}_{DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-f".Replace('-', '_'))}";
        //        string path = downloads + $"/{fullzipname}.zip";

        //        int filecount = 1;
        //        zip = ZipFile.Open(path, ZipArchiveMode.Create);
        //        using (zip)
        //        {
        //            foreach (var file in filesToZip)
        //            {
        //                //// Make sure Content Type is Picture or Pdf or Word
        //                if (!((file.Item1.Contains("jpeg", StringComparison.InvariantCultureIgnoreCase)) || (file.Item1.Contains("jpg", StringComparison.InvariantCultureIgnoreCase)) || (file.Item1.Contains("png", StringComparison.InvariantCultureIgnoreCase)) || (file.Item1.Contains("pdf", StringComparison.InvariantCultureIgnoreCase)) || (file.Item1.Contains("doc", StringComparison.InvariantCultureIgnoreCase)) || (file.Item1.Contains("docx", StringComparison.InvariantCultureIgnoreCase))))
        //                {
        //                    //logger.LogInformation("Invalid file type for file {fileName}");

        //                    continue;
        //                }

        //                //get file from base64
        //                IFormFile sourcefile = await DecodeFileFromBase64String(file.Item2, file.Item1);
        //                var sourcefilepath = $"{downloads}/{sourcefile.FileName}";
        //                string fileNameInZip = $"zippedfile_{filecount}_{DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-f".Replace('-', '_'))}.{file.Item1}";
        //                zip.CreateEntryFromFile(sourcefilepath, fileNameInZip);
        //                filecount++;
        //            }
        //        }

        //        base64String = await ConvertFilePathToBase64String(fullzipname, "zip");
        //        return base64String;
        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error occurred");

        //        return null;
        //    }
        //}

        //public async Task<IFormFile> GetUploadedFileFromName(string name, string ext)
        //{
        //    //logger.LogInformation("Inside the {method} method.", nameof(GetUploadedFileFromName));
        //    try
        //    {
        //        // Setup
        //        IFormFile formFile;

        //        // Get Upload folder path
        //        string uploads = Path.Combine(environment.WebRootPath, "Uploads");

        //        if (!Directory.Exists(uploads))
        //        {
        //            Directory.CreateDirectory(uploads);
        //        }

        //        // Get file
        //        string fullpath = $"{uploads}/{name}.{ext}";
        //        FileStream stream = new FileStream(uploads + $"/retrievedFile_{name}_{DateTime.Now.ToString("yy-MM-dd-HH-mm-ss-f".Replace('-', '_'))}.{ext}", FileMode.Create);//new FileStream(fullpath, FileMode.Open);

        //        using (stream)
        //        {
        //            // Return file as IFormFile
        //            formFile = new FormFile(stream, 0, stream.Length, null, $"{name}_formfile.{ext}")
        //            {
        //                //ContentType = ext.Equals("png", StringComparison.InvariantCultureIgnoreCase) ? "image/png"
        //                //    : ext.Equals("jpg", StringComparison.InvariantCultureIgnoreCase) ? "image/jpeg"
        //                //    : $"application/{ext}"
        //            };
        //        }

        //        //logger.LogInformation("Successfully converted string to file {fileName}", JsonConvert.SerializeObject(formFile.FileName));

        //        return formFile;
        //    }
        //    catch (Exception ex)
        //    {
        //        //logger.LogError(ex, "An error ccurred while converting string to file");

        //        return null;
        //    }
        //}

        public async Task<string> GetFullFilePathFromName(string name)
        {
            //logger.LogInformation("Inside the {method} method.", nameof(GetUploadedFileFromName));
            try
            {
                // Setup
                string fullPath;

                // Get image folder path
                string fullimagefolder = Path.Combine(environment.WebRootPath, imagesFolder);

                if (!Directory.Exists(fullimagefolder))
                {
                    Directory.CreateDirectory(fullimagefolder);
                }

                // Get file
                fullPath = $"{fullimagefolder}/{name}";

                return fullPath;
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "An error ccurred while converting string to file");

                return null;
            }
        }

        public async Task<string> GetFullFileURLFromName(string name)
        {
            //logger.LogInformation("Inside the {method} method.", nameof(GetUploadedFileFromName));
            try
            {
                // Setup
                string fullURLPath = $"{config["AppPath"]}/{imagesFolder}/{name}"; 

                return fullURLPath;
            }
            catch (Exception ex)
            {
                //logger.LogError(ex, "An error ccurred while converting string to file");

                return null;
            }
        }
    }
}
