# VisionAndProjectionService.Swagger.Api.TargetsApi

All URIs are relative to *http://localhost:9015*

 Method                                                                                                         | HTTP request                           | Description                                                                             
----------------------------------------------------------------------------------------------------------------|----------------------------------------|-----------------------------------------------------------------------------------------
 [**CoreLaserServiceGetPhysicalTargets**](TargetsApi.md#corelaserservicegetphysicaltargets)                     | **POST** /GetPhysicalTargets           | Returns all targets specified in the Work Order.                                        
 [**CoreLaserServiceGetProjectorAlignmentTargets**](TargetsApi.md#corelaserservicegetprojectoralignmenttargets) | **POST** /GetProjectorAlignmentTargets | Returns a collection of all targets that ARE being used by the specified projector.     
 [**CoreLaserServiceGetUnusedTargets**](TargetsApi.md#corelaserservicegetunusedtargets)                         | **POST** /GetUnusedTargets             | Returns a collection of all targets that are NOT being used by the specified projector. 

<a name="corelaserservicegetphysicaltargets"></a>

# **CoreLaserServiceGetPhysicalTargets**

> ResultDtoListPhysicalTargetDto CoreLaserServiceGetPhysicalTargets (ClientIdDto clientId)

Returns all targets specified in the Work Order.

Returns a collection of all targets (PhysicalTargetDto) specified in the Work Order, regardless of type or whether they
are disabled. See PhysicalTargetDto in the Integrators Guide for interpretation.

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetPhysicalTargetsExample
    {
        public void main()
        {
            var apiInstance = new TargetsApi();
            var clientId = new ClientIdDto(); // ClientIdDto | 

            try
            {
                // Returns all targets specified in the Work Order.
                ResultDtoListPhysicalTargetDto result = apiInstance.CoreLaserServiceGetPhysicalTargets(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TargetsApi.CoreLaserServiceGetPhysicalTargets: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) |             |

### Return type

[**ResultDtoListPhysicalTargetDto**](ResultDtoListPhysicalTargetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectoralignmenttargets"></a>

# **CoreLaserServiceGetProjectorAlignmentTargets**

> ResultDtoListProjectorTargetDto CoreLaserServiceGetProjectorAlignmentTargets (ClientProjectorInfoDto
> clientProjectorInfo)

Returns a collection of all targets that ARE being used by the specified projector.

Returns information (`ProjectorTargetDto`) about all targets that exist in the Work Order (see `/GetPhysicalTargets`)
that are being used by this projector. Besides nominal target information from the Work Order (`PhysicalTargetDto`), the
return payload will include additional information about how the projector scans each target. See `ProjectorTargetDto`
in the Integrators Guide for more information.  <example>              ClientProjectorInfoDto { ClientId (string,
required), ProjectorSerial (string, required)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorAlignmentTargetsExample
    {
        public void main()
        {
            var apiInstance = new TargetsApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | Stores client Projector combination of information(client Id , Projector Serial)

            try
            {
                // Returns a collection of all targets that ARE being used by the specified projector.
                ResultDtoListProjectorTargetDto result = apiInstance.CoreLaserServiceGetProjectorAlignmentTargets(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TargetsApi.CoreLaserServiceGetProjectorAlignmentTargets: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                    | Type                                                    | Description                                                                      | Notes 
-------------------------|---------------------------------------------------------|----------------------------------------------------------------------------------|-------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md) | Stores client Projector combination of information(client Id , Projector Serial) |

### Return type

[**ResultDtoListProjectorTargetDto**](ResultDtoListProjectorTargetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetunusedtargets"></a>

# **CoreLaserServiceGetUnusedTargets**

> ResultDtoListProjectorTargetDto CoreLaserServiceGetUnusedTargets (ClientProjectorInfoDto clientProjectorInfo)

Returns a collection of all targets that are NOT being used by the specified projector.

Returns information (`ProjectorTargetDto`) about all the targets that exist in the Work Order (see
`/GetPhysicalTargets`) that are not being used by the specified projector, either because it cannot physically see/scan
them or they have been disabled. Returns a `ProjectorTargetDto`, however for targets that are not seen or used by this
projector much of the information will be null/default/empty.  <example>              ClientProjectorInfoDto {
ClientId (string, required), ProjectorSerial (string, required)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetUnusedTargetsExample
    {
        public void main()
        {
            var apiInstance = new TargetsApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | Stores client Projector combination of information(client Id , Projector Serial)

            try
            {
                // Returns a collection of all targets that are NOT being used by the specified projector.
                ResultDtoListProjectorTargetDto result = apiInstance.CoreLaserServiceGetUnusedTargets(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TargetsApi.CoreLaserServiceGetUnusedTargets: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                    | Type                                                    | Description                                                                      | Notes 
-------------------------|---------------------------------------------------------|----------------------------------------------------------------------------------|-------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md) | Stores client Projector combination of information(client Id , Projector Serial) |

### Return type

[**ResultDtoListProjectorTargetDto**](ResultDtoListProjectorTargetDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

