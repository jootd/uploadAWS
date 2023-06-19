
using UploadToAWS.Upload;

namespace UploadToAWS
{
    class Program
    {
        static void Main(string[] args) {

            string filePath = "";
            string myBucketName = "";
            string s3DirName = "";
            string s3FileName = @"";
            var uploader = new AmzaonUploader();
            uploader.sendMyFileToS3(filePath, myBucketName, s3DirName, s3FileName)

                
                
         }

    }

}