# VisionAndProjectionService.Swagger.Api.TransformsApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CoreLaserServiceResetProjectionShift**](TransformsApi.md#corelaserserviceresetprojectionshift) | **POST** /ResetProjectionShift | Removes any applied Shift Translation or Rotation.
[**CoreLaserServiceRotateProjection**](TransformsApi.md#corelaserservicerotateprojection) | **POST** /RotateProjection | Rotates projection.
[**CoreLaserServiceShiftProjection**](TransformsApi.md#corelaserserviceshiftprojection) | **POST** /ShiftProjection | Shifts projection.


<a name="corelaserserviceresetprojectionshift"></a>
# **CoreLaserServiceResetProjectionShift**
> ResultDtoCumulativeShiftingValuesDto CoreLaserServiceResetProjectionShift (ClientInfoDto clientInfo)

Removes any applied Shift Translation or Rotation.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceResetProjectionShiftExample
    {
        public void main()
        {
            var apiInstance = new TransformsApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | Client information

            try
            {
                // Removes any applied Shift Translation or Rotation.
                ResultDtoCumulativeShiftingValuesDto result = apiInstance.CoreLaserServiceResetProjectionShift(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransformsApi.CoreLaserServiceResetProjectionShift: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| Client information | 

### Return type

[**ResultDtoCumulativeShiftingValuesDto**](ResultDtoCumulativeShiftingValuesDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicerotateprojection"></a>
# **CoreLaserServiceRotateProjection**
> ResultDtoCumulativeShiftingValuesDto CoreLaserServiceRotateProjection (ClientRotationDto clientRotationDto)

Rotates projection.

Rotates all Work Order projection in the Direction specified (Clockwise, CounterClockwise); same as pressing the \"Rotate Clockwise/Counter-clockwise\" buttons in Iris Client. The fixed rotation amount (in Degrees) is specified as \"Shift Rotation in Degrees\" under Virtek Server: Projection Options in Virtek Server Manager or in Iris Client &gt; Configuration: Projection Options..   Returns the cumulative or net effect of all x/y shifts and rotations that are currently applied to this Work Order.    See \"Using the Shift Feature\" in either Iris Operator or Administrator guides for details on how translation information is applied relative to surface geometries.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceRotateProjectionExample
    {
        public void main()
        {
            var apiInstance = new TransformsApi();
            var clientRotationDto = new ClientRotationDto(); // ClientRotationDto | 

            try
            {
                // Rotates projection.
                ResultDtoCumulativeShiftingValuesDto result = apiInstance.CoreLaserServiceRotateProjection(clientRotationDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransformsApi.CoreLaserServiceRotateProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientRotationDto** | [**ClientRotationDto**](ClientRotationDto.md)|  | 

### Return type

[**ResultDtoCumulativeShiftingValuesDto**](ResultDtoCumulativeShiftingValuesDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceshiftprojection"></a>
# **CoreLaserServiceShiftProjection**
> ResultDtoCumulativeShiftingValuesDto CoreLaserServiceShiftProjection (ClientShiftingDto clientShiftingDto)

Shifts projection.

Translates projection in the corresponding direction (Up/Down/Left/Right); same as pressing the \"Up/Down/Left/Right Shift\" buttons in Iris Client. The fixed shift amount is specified as \"Shift Translation\" in Iris Client: Projection Options as system default in Virtek Server: Projection Options.   Returns the cumulative or net effect of all x/y shifts and rotations that are currently applied to this Work Order.  Note that in Iris Client or Virtek Server Manager translation amounts are show in Display Units, while here they are listed in feet.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceShiftProjectionExample
    {
        public void main()
        {
            var apiInstance = new TransformsApi();
            var clientShiftingDto = new ClientShiftingDto(); // ClientShiftingDto | Client information and shifting direction

            try
            {
                // Shifts projection.
                ResultDtoCumulativeShiftingValuesDto result = apiInstance.CoreLaserServiceShiftProjection(clientShiftingDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TransformsApi.CoreLaserServiceShiftProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientShiftingDto** | [**ClientShiftingDto**](ClientShiftingDto.md)| Client information and shifting direction | 

### Return type

[**ResultDtoCumulativeShiftingValuesDto**](ResultDtoCumulativeShiftingValuesDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

