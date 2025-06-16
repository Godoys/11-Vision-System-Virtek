# VisionAndProjectionService.Swagger.Api.IrisApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CoreLaserServiceAddManualClippingBoundaries**](IrisApi.md#corelaserserviceaddmanualclippingboundaries) | **POST** /AddManualClippingBoundaries | Adds Work Order + Projector specific Manual Clipping Boundaries
[**CoreLaserServiceCanProjectorExportData**](IrisApi.md#corelaserservicecanprojectorexportdata) | **POST** /CanProjectorExportData | Confirms if a projector can participate in File Management.
[**CoreLaserServiceEnableProjectText**](IrisApi.md#corelaserserviceenableprojecttext) | **POST** /EnableProjectText | Toggles the behaviour of Projected Text steps.
[**CoreLaserServiceGetProjectorTemperature**](IrisApi.md#corelaserservicegetprojectortemperature) | **POST** /GetProjectorTemperature | Returns inside case temperature of the specified laser projector in Celsius.
[**CoreLaserServiceGetProjectorsSupportingVisionAlignment**](IrisApi.md#corelaserservicegetprojectorssupportingvisionalignment) | **POST** /GetProjectorsSupportingVisionAlignment | Returns a list of all projectors capable of FlashAlignment.
[**CoreLaserServiceGetSerialGalvoX**](IrisApi.md#corelaserservicegetserialgalvox) | **POST** /GetSerialGalvoX | Returns X galvanometer serial number of the specified projector.
[**CoreLaserServiceGetSerialGalvoY**](IrisApi.md#corelaserservicegetserialgalvoy) | **POST** /GetSerialGalvoY | Returns Y galvanometer serial number of the specified projector.


<a name="corelaserserviceaddmanualclippingboundaries"></a>
# **CoreLaserServiceAddManualClippingBoundaries**
> ResultDto CoreLaserServiceAddManualClippingBoundaries (ManualClippingConfigurationDto clippingConfig)

Adds Work Order + Projector specific Manual Clipping Boundaries

See \"Manual Clipping Boundaries\" in Iris System Administrator's Guide.    A Manual Clipping Boundary is defined by one or more clipping planes each specified as:  * a point through which the plane passes  * a normal vector, orthogonal to the plane that points \"in\" towards the projection area that is being assigned to this projector.  Unlike most other API methods which operate with projectors named explicitly with serial #,  clipping boundaries are best used in defined Work Cell configurations (See \"Work Cells\" and \"Projector Replacement\" in Iris Administrator's Guide), so here boundaries are specified using Projector Familiar Names instead of serial #.    Manual Clipping Boundaries can be added to Work Orders that aren't even loaded; there is no `/RemoveManualClippingBoundaries` or `/EditManualClippingBoundaries` however - changes or deletion will have to be done via Iris Client: Work Order Options \"Manual Clipping Boundaries\".    <example>               ManualClippingConfigurationDto {                 ClientInfo (ClientInfoDto, optional),                 WorkOrderName (string, optional),                 ClippingBoundary (Array[ClippingBoundaryDto], optional)                 }                             ClippingBoundaryDto {                Name (string, optional),                ProjectorFamiliarName (string, optional),                ClippingPlanes (Array[ClippingPlaneDto], optional)                }                              ClippingPlaneDto {                PlaneLocation (VertexDto, optional),                PlaneNormal (VertexDto, optional)               }               </example>  * **WorkOrderName** - name/Work Order folder  * **ProjectorFamiliarName** - Familiar/friendly name of the projector - if familiar names aren't being used, use the serial number; without Familiar Names, however, the clipping boundary will have to be respecified if different projectors are used with this Work Order.  * **PlaneLocation** - a plane through this point forms part of the projector's projection volume along with:  * **PlaneNormal** - vector indicating \"in\" to the projector's projection volume. (See VertexDto above)

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceAddManualClippingBoundariesExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clippingConfig = new ManualClippingConfigurationDto(); // ManualClippingConfigurationDto | the configred clipping data

            try
            {
                // Adds Work Order + Projector specific Manual Clipping Boundaries
                ResultDto result = apiInstance.CoreLaserServiceAddManualClippingBoundaries(clippingConfig);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceAddManualClippingBoundaries: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clippingConfig** | [**ManualClippingConfigurationDto**](ManualClippingConfigurationDto.md)| the configred clipping data | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicecanprojectorexportdata"></a>
# **CoreLaserServiceCanProjectorExportData**
> ResultDtoBoolean CoreLaserServiceCanProjectorExportData (ClientProjectorInfoDto clientProjectorInfo)

Confirms if a projector can participate in File Management.

Returns true if a laser projector can provide required projection files to the system when required (see \"Projector File Management\" in the Iris System Administrator Guide.)  If a projector does NOT support this feature then local sources of the projector's required projection files must be made available to the system from installation media provided with the projector.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCanProjectorExportDataExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | client Projector information

            try
            {
                // Confirms if a projector can participate in File Management.
                ResultDtoBoolean result = apiInstance.CoreLaserServiceCanProjectorExportData(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceCanProjectorExportData: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| client Projector information | 

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceenableprojecttext"></a>
# **CoreLaserServiceEnableProjectText**
> ResultDto CoreLaserServiceEnableProjectText (ClientFlagDto clientFlag)

Toggles the behaviour of Projected Text steps.

Toggles the same parameter as Iris Client &gt; Options: Project Text; when on(true) all Projected Text markers are automatically shown (although the Operator can hide them); if off (false), Projected Text icons remain hidden (in chevron form) until expanded by the Operator; on ply/step change. See \"Iris Client: Projection Options\" and \"Work Order Options\" in Iris System Administrator Guide.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceEnableProjectTextExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientFlag = new ClientFlagDto(); // ClientFlagDto | 

            try
            {
                // Toggles the behaviour of Projected Text steps.
                ResultDto result = apiInstance.CoreLaserServiceEnableProjectText(clientFlag);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceEnableProjectText: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientFlag** | [**ClientFlagDto**](ClientFlagDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectortemperature"></a>
# **CoreLaserServiceGetProjectorTemperature**
> ResultDtoDouble CoreLaserServiceGetProjectorTemperature (ClientProjectorInfoDto clientProjectorInfo)

Returns inside case temperature of the specified laser projector in Celsius.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorTemperatureExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns inside case temperature of the specified laser projector in Celsius.
                ResultDtoDouble result = apiInstance.CoreLaserServiceGetProjectorTemperature(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceGetProjectorTemperature: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)|  | 

### Return type

[**ResultDtoDouble**](ResultDtoDouble.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectorssupportingvisionalignment"></a>
# **CoreLaserServiceGetProjectorsSupportingVisionAlignment**
> ResultDtoListString CoreLaserServiceGetProjectorsSupportingVisionAlignment (ClientIdDto clientId)

Returns a list of all projectors capable of FlashAlignment.

Provides a list (array of serial #s) of projectors visible to the system with vision systems capable  of FlashAlignment.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorsSupportingVisionAlignmentExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientId = new ClientIdDto(); // ClientIdDto | 

            try
            {
                // Returns a list of all projectors capable of FlashAlignment.
                ResultDtoListString result = apiInstance.CoreLaserServiceGetProjectorsSupportingVisionAlignment(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceGetProjectorsSupportingVisionAlignment: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientId** | [**ClientIdDto**](ClientIdDto.md)|  | 

### Return type

[**ResultDtoListString**](ResultDtoListString.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetserialgalvox"></a>
# **CoreLaserServiceGetSerialGalvoX**
> ResultDtoString CoreLaserServiceGetSerialGalvoX (ClientProjectorInfoDto clientProjectorInfo)

Returns X galvanometer serial number of the specified projector.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetSerialGalvoXExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns X galvanometer serial number of the specified projector.
                ResultDtoString result = apiInstance.CoreLaserServiceGetSerialGalvoX(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceGetSerialGalvoX: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)|  | 

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetserialgalvoy"></a>
# **CoreLaserServiceGetSerialGalvoY**
> ResultDtoString CoreLaserServiceGetSerialGalvoY (ClientProjectorInfoDto clientProjectorInfo)

Returns Y galvanometer serial number of the specified projector.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetSerialGalvoYExample
    {
        public void main()
        {
            var apiInstance = new IrisApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns Y galvanometer serial number of the specified projector.
                ResultDtoString result = apiInstance.CoreLaserServiceGetSerialGalvoY(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling IrisApi.CoreLaserServiceGetSerialGalvoY: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)|  | 

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

