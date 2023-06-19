using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;

public namespace UploadToAWS.Upload
{
    public  class AmzaonUploader
    {
        public bool sendMyFileToS3(string localFilePath, string bucketName, string subDirectoryInBucket, string fileNameInS3)
        {


            var secretConsumer = new SecretConsumer();
            IAmazonS3 client = new AmazonS3Client(secretConsumer.AWSAccessKey, secretConsumer.AWSSecretKey, RegionEndpoint.EUCentral1);

            var  utility = new TransferUtility(client);
            var request = new TransferUtilityUploadRequest();
            if (subDirectoryInBucket == "" || subDirectoryInBucket == null)
            {
                request.BucketName = bucketName;
            }
            else
            {
                request.BucketName = bucketName + @"/" + subDirectoryInBucket;
            }
            request.Key = fileNameInS3;
            request.FilePath=localFilePath;

            utility.Upload(request);
            
            return true;
        }
    }
}
