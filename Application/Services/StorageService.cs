using Amazon.Runtime;
using Amazon.S3;
using Amazon;
using Application.Dtos.ResponseModel;
using Application.IServices;
using Microsoft.AspNetCore.Http;
using Amazon.S3.Model;

namespace Application.Services
{
    public class StorageService:IStorageService
    {
        private static string bucketName = "nash-book";
        public BaseResponse<string> GetStorageUrl(IFormFile file)
        {
            double timeoutDuration = 12;
            AWSConfigsS3.UseSignatureVersion4 = true;
            IAmazonS3 client = new AmazonS3Client(new EnvironmentVariablesAWSCredentials());
            var url = GeneratePreSignedURL(client, bucketName, file.ContentType, file.FileName, timeoutDuration);
            return new BaseResponse<string>
            {
                StatusCode = 200,
                Body = url
            };

        }

        public async Task<BaseResponse<string>> GetObjectFinalVersionId(string objectKey)
        {
            IAmazonS3 client = new AmazonS3Client(new EnvironmentVariablesAWSCredentials());
            ListVersionsRequest request = new ListVersionsRequest()
            {
                BucketName = bucketName,
                Prefix = objectKey
            };
            ListVersionsResponse response = await client.ListVersionsAsync(request);
            if (response.Versions.Count == 0)
            {
                return new BaseResponse<string>
                {
                    StatusCode = 404,
                    Message = "File not exist in storage"
                };
            }
            var versionId = response.Versions.First().VersionId;
            return new BaseResponse<string>
            {
                StatusCode = 200,
                Body = versionId == "null" ? String.Empty : versionId
            };

        }

        private static string GeneratePreSignedURL(IAmazonS3 client, string bucketName, string contentType, string objectKey, double duration)
        {
            var request = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = objectKey,
                Verb = HttpVerb.PUT,
                Expires = DateTime.UtcNow.AddHours(duration),
                ContentType = contentType,
            };

            string url = client.GetPreSignedURL(request);
            return url;
        }

    }
}
