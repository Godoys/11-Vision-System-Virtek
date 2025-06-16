# VisionAndProjectionService.Swagger.Api.VisionApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**VisionAndProjectionServiceCaptureRawImage**](VisionApi.md#visionandprojectionservicecapturerawimage) | **POST** /CaptureRawImage | Capture an image using a VPS projector camera
[**VisionAndProjectionServiceResetProjectorLink**](VisionApi.md#visionandprojectionserviceresetprojectorlink) | **POST** /ResetProjectorLink | Reset The Camera to Projector  Link Known in Iris as F11 Calibration, for this to work the client should not have any work order open and the projector should not be projecting


<a name="visionandprojectionservicecapturerawimage"></a>
# **VisionAndProjectionServiceCaptureRawImage**
> ResultDtoCameraImageDto VisionAndProjectionServiceCaptureRawImage (RawImageCameraDto cameraIndexDto)

Capture an image using a VPS projector camera

Returns information about the image capture. This includes the Camera ID, image data (RAW format), width, height, X and Y aspect ratios, and  view point data. For an example on how to process the RAW image data returned by this endpoint, consult the API Sample Application for this Iris / Virtek Server release.  * Camera index 0 is left, 1 is right  <example>              RawImageCameraDto {                  CameraIndex (int, required),                  ProjectorSerial (string, required)              }              </example>

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class VisionAndProjectionServiceCaptureRawImageExample
    {
        public void main()
        {
            var apiInstance = new VisionApi();
            var cameraIndexDto = new RawImageCameraDto(); // RawImageCameraDto | Projector serial and Camera index relative to parent locator

            try
            {
                // Capture an image using a VPS projector camera
                ResultDtoCameraImageDto result = apiInstance.VisionAndProjectionServiceCaptureRawImage(cameraIndexDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VisionApi.VisionAndProjectionServiceCaptureRawImage: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **cameraIndexDto** | [**RawImageCameraDto**](RawImageCameraDto.md)| Projector serial and Camera index relative to parent locator | 

### Return type

[**ResultDtoCameraImageDto**](ResultDtoCameraImageDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="visionandprojectionserviceresetprojectorlink"></a>
# **VisionAndProjectionServiceResetProjectorLink**
> ResultDto VisionAndProjectionServiceResetProjectorLink (ClientProjectorInfoDto deviceInfo)

Reset The Camera to Projector  Link Known in Iris as F11 Calibration, for this to work the client should not have any work order open and the projector should not be projecting

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class VisionAndProjectionServiceResetProjectorLinkExample
    {
        public void main()
        {
            var apiInstance = new VisionApi();
            var deviceInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | This contains the information that is needed to identify the device that is being calibrated

            try
            {
                // Reset The Camera to Projector  Link Known in Iris as F11 Calibration, for this to work the client should not have any work order open and the projector should not be projecting
                ResultDto result = apiInstance.VisionAndProjectionServiceResetProjectorLink(deviceInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling VisionApi.VisionAndProjectionServiceResetProjectorLink: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **deviceInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| This contains the information that is needed to identify the device that is being calibrated | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

