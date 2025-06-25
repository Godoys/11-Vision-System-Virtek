# WorkorderService.Swagger.Api.WorkOrderOperationsApi

All URIs are relative to *http://localhost:9020*

 Method                                                                                                                 | HTTP request                         | Description                                                                                                                   
------------------------------------------------------------------------------------------------------------------------|--------------------------------------|-------------------------------------------------------------------------------------------------------------------------------
 [**WorkOrderServiceConvertToPly**](WorkOrderOperationsApi.md#workorderserviceconverttoply)                             | **POST** /ConvertToPly               | convert file to ply file.                                                                                                     
 [**WorkOrderServiceDeleteInspectionCache**](WorkOrderOperationsApi.md#workorderservicedeleteinspectioncache)           | **PUT** /DeleteInspectionCache       | Delete work orders created by inspection files                                                                                
 [**WorkOrderServiceEditingWOConvertCadFile**](WorkOrderOperationsApi.md#workorderserviceeditingwoconvertcadfile)       | **POST** /EditingWOConvertCadFile    | Edit Work Order attributes.                                                                                                   
 [**WorkOrderServiceGetCadFileList**](WorkOrderOperationsApi.md#workorderservicegetcadfilelist)                         | **GET** /GetCadFileList              | Returns a list of available CAD files within the CAD Directory.                                                               
 [**WorkOrderServiceGetCurrentWorkOrderName**](WorkOrderOperationsApi.md#workorderservicegetcurrentworkordername)       | **POST** /GetCurrentWorkOrderName    | This is used to get the current loaded work order name by given client.                                                       
 [**WorkOrderServiceGetNailInfoCsvData**](WorkOrderOperationsApi.md#workorderservicegetnailinfocsvdata)                 | **POST** /GetNailInfoCsvData         | Get work order nail info csv data                                                                                             
 [**WorkOrderServiceGetPanelBoundary**](WorkOrderOperationsApi.md#workorderservicegetpanelboundary)                     | **GET** /GetPanelBoundary            | Get work order panel boundary                                                                                                 
 [**WorkOrderServiceGetStudsCsvData**](WorkOrderOperationsApi.md#workorderservicegetstudscsvdata)                       | **POST** /GetStudsCsvData            | Get work order nail info csv data                                                                                             
 [**WorkOrderServiceGetWorkOrderDirectoryPath**](WorkOrderOperationsApi.md#workorderservicegetworkorderdirectorypath)   | **GET** /GetWorkOrderDirectoryPath   | Returns the current Work Order Directory path.                                                                                
 [**WorkOrderServiceGetWorkOrdersList**](WorkOrderOperationsApi.md#workorderservicegetworkorderslist)                   | **POST** /GetWorkOrdersList          | Returns a list of available Work Orders.                                                                                      
 [**WorkOrderServiceGetWorkOrdersListAndStatus**](WorkOrderOperationsApi.md#workorderservicegetworkorderslistandstatus) | **POST** /GetWorkOrdersListAndStatus | Returns a list of available Work Orders and status if the service has finished loading all workorders in configured directory 
 [**WorkOrderServiceLoadWorkOrder**](WorkOrderOperationsApi.md#workorderserviceloadworkorder)                           | **POST** /LoadWorkOrder              | Returns a Work Order&#39;s raw projection data.                                                                               
 [**WorkOrderServiceValidateSelectedWorkOrder**](WorkOrderOperationsApi.md#workorderservicevalidateselectedworkorder)   | **POST** /ValidateSelectedWorkOrder  | Performs validation checks on the specified Work Order.                                                                       

<a name="workorderserviceconverttoply"></a>

# **WorkOrderServiceConvertToPly**

> ResultDtoPlyConversionResultDto WorkOrderServiceConvertToPly (PathDto path)

convert file to ply file.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceConvertToPlyExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var path = new PathDto(); // PathDto | path of the file to load info

            try
            {
                // convert file to ply file.
                ResultDtoPlyConversionResultDto result = apiInstance.WorkOrderServiceConvertToPly(path);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceConvertToPly: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name     | Type                      | Description                   | Notes 
----------|---------------------------|-------------------------------|-------
 **path** | [**PathDto**](PathDto.md) | path of the file to load info |

### Return type

[**ResultDtoPlyConversionResultDto**](ResultDtoPlyConversionResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicedeleteinspectioncache"></a>

# **WorkOrderServiceDeleteInspectionCache**

> ResultDto WorkOrderServiceDeleteInspectionCache (DeleteAllInspectionResultRequestDto timeStampDto)

Delete work orders created by inspection files

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceDeleteInspectionCacheExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var timeStampDto = new DeleteAllInspectionResultRequestDto(); // DeleteAllInspectionResultRequestDto | The timestamp to remove cache

            try
            {
                // Delete work orders created by inspection files
                ResultDto result = apiInstance.WorkOrderServiceDeleteInspectionCache(timeStampDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceDeleteInspectionCache: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name             | Type                                                                              | Description                   | Notes 
------------------|-----------------------------------------------------------------------------------|-------------------------------|-------
 **timeStampDto** | [**DeleteAllInspectionResultRequestDto**](DeleteAllInspectionResultRequestDto.md) | The timestamp to remove cache |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderserviceeditingwoconvertcadfile"></a>

# **WorkOrderServiceEditingWOConvertCadFile**

> ResultDtoString WorkOrderServiceEditingWOConvertCadFile (WorkOrderEditDto workOrderEdit)

Edit Work Order attributes.

API equivalent of the Edit Work Order (ALT+E) dialogue in Iris Client. In mirror with the Edit Work Order dialogue, only
the CAD file associated with the Work Order can be modified.  (projection aka .ply files can't be changed yet.)  * *
*ClientID** - the client session of this ID * **WorkOrderName** - the name of the Work Order as returned by
`/GetWorkOrderList` and `/GetWorkOrderListAndStatus`. * **CadFilePath** - the path to the CAD model file to associate
with the named Work Order (as it would appear to the CAD Service). ClientID is really for logging purposes only; IF the
CAD file specified is legitimate and can be located by the CAD Service, then the Work Order's database will be updated
with a CAD File update message as though it were Edited in Iris Client by the specified ClientID. The CAD File Path can
either be absolute (on Virtek Server; or wherever the CAD service is running) or it can be relative from `CAD Directory`
as specified in Virtek Server Manager &gt; Server Configurations &gt; File Location.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceEditingWOConvertCadFileExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var workOrderEdit = new WorkOrderEditDto(); // WorkOrderEditDto | 

            try
            {
                // Edit Work Order attributes.
                ResultDtoString result = apiInstance.WorkOrderServiceEditingWOConvertCadFile(workOrderEdit);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceEditingWOConvertCadFile: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                        | Description | Notes 
-------------------|---------------------------------------------|-------------|-------
 **workOrderEdit** | [**WorkOrderEditDto**](WorkOrderEditDto.md) |             |

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetcadfilelist"></a>

# **WorkOrderServiceGetCadFileList**

> ResultDtoListString WorkOrderServiceGetCadFileList ()

Returns a list of available CAD files within the CAD Directory.

Lists all CAD files - aka files (including in subfolders) within the `CAD Directory`  specified in Virtek Server Manager
&gt; Server Configurations &gt; File Location.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetCadFileListExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();

            try
            {
                // Returns a list of available CAD files within the CAD Directory.
                ResultDtoListString result = apiInstance.WorkOrderServiceGetCadFileList();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetCadFileList: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoListString**](ResultDtoListString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetcurrentworkordername"></a>

# **WorkOrderServiceGetCurrentWorkOrderName**

> ResultDtoWorkOrderNameDto WorkOrderServiceGetCurrentWorkOrderName (ClientIdDto clientIdDto)

This is used to get the current loaded work order name by given client.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetCurrentWorkOrderNameExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var clientIdDto = new ClientIdDto(); // ClientIdDto | requested client id

            try
            {
                // This is used to get the current loaded work order name by given client.
                ResultDtoWorkOrderNameDto result = apiInstance.WorkOrderServiceGetCurrentWorkOrderName(clientIdDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetCurrentWorkOrderName: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                              | Description         | Notes 
-----------------|-----------------------------------|---------------------|-------
 **clientIdDto** | [**ClientIdDto**](ClientIdDto.md) | requested client id |

### Return type

[**ResultDtoWorkOrderNameDto**](ResultDtoWorkOrderNameDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetnailinfocsvdata"></a>

# **WorkOrderServiceGetNailInfoCsvData**

> ResultDtoNailInfoDataListDto WorkOrderServiceGetNailInfoCsvData (WorkOrderNameDto workOrder)

Get work order nail info csv data

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetNailInfoCsvDataExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var workOrder = new WorkOrderNameDto(); // WorkOrderNameDto | work order name

            try
            {
                // Get work order nail info csv data
                ResultDtoNailInfoDataListDto result = apiInstance.WorkOrderServiceGetNailInfoCsvData(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetNailInfoCsvData: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type                                        | Description     | Notes 
---------------|---------------------------------------------|-----------------|-------
 **workOrder** | [**WorkOrderNameDto**](WorkOrderNameDto.md) | work order name |

### Return type

[**ResultDtoNailInfoDataListDto**](ResultDtoNailInfoDataListDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetpanelboundary"></a>

# **WorkOrderServiceGetPanelBoundary**

> ResultDtoPanelBoundaryDto WorkOrderServiceGetPanelBoundary ()

Get work order panel boundary

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetPanelBoundaryExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();

            try
            {
                // Get work order panel boundary
                ResultDtoPanelBoundaryDto result = apiInstance.WorkOrderServiceGetPanelBoundary();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetPanelBoundary: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoPanelBoundaryDto**](ResultDtoPanelBoundaryDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetstudscsvdata"></a>

# **WorkOrderServiceGetStudsCsvData**

> ResultDtoStudsDataDto WorkOrderServiceGetStudsCsvData (WorkOrderNameDto workOrderNameDto)

Get work order nail info csv data

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetStudsCsvDataExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var workOrderNameDto = new WorkOrderNameDto(); // WorkOrderNameDto | 

            try
            {
                // Get work order nail info csv data
                ResultDtoStudsDataDto result = apiInstance.WorkOrderServiceGetStudsCsvData(workOrderNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetStudsCsvData: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                 | Type                                        | Description | Notes 
----------------------|---------------------------------------------|-------------|-------
 **workOrderNameDto** | [**WorkOrderNameDto**](WorkOrderNameDto.md) |             |

### Return type

[**ResultDtoStudsDataDto**](ResultDtoStudsDataDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetworkorderdirectorypath"></a>

# **WorkOrderServiceGetWorkOrderDirectoryPath**

> ResultDtoWorkOrderDirectoryPathDto WorkOrderServiceGetWorkOrderDirectoryPath ()

Returns the current Work Order Directory path.

Shows the full absolute path currently configured as \"Work Order Folder\" in Virtek Server Manager &gt; File Locations.
All Work Orders used by Iris are searched for in this folder.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetWorkOrderDirectoryPathExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();

            try
            {
                // Returns the current Work Order Directory path.
                ResultDtoWorkOrderDirectoryPathDto result = apiInstance.WorkOrderServiceGetWorkOrderDirectoryPath();
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetWorkOrderDirectoryPath: " + e.Message );
            }
        }
    }
}
```

### Parameters

This endpoint does not need any parameter.

### Return type

[**ResultDtoWorkOrderDirectoryPathDto**](ResultDtoWorkOrderDirectoryPathDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: Not defined
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetworkorderslist"></a>

# **WorkOrderServiceGetWorkOrdersList**

> ResultDtoListWorkOrderDto WorkOrderServiceGetWorkOrdersList (GetWorkOrdersListDto getWorkOrdersListDto)

Returns a list of available Work Orders.

Lists all Work Orders - aka folders within \"Work Order Folder\" in Virtek Server Manager &gt; File Locations - subject
to the optional feature filters. If more than one of these are specified a logical AND is performed to create the result
set. To distinguish, each Work Order in the returned collection of WorkOrderDtos will have to be assessed. * *
*ClientProjectionFileUnits** - return Work Orders that use these units (see Units in Integrator's Guide)  * *
*DigitizationEnabled** - return Work Orders that use digitization; SPS only; currently unused. * **SPSENabled** - return
Work Orders that use SPS alignment not targeted/3D/FlashAlignment. * **ProjectionFileAvailable** - return Work Orders
that have valid .ply files.  <example>               GetWorkOrdersListDto { ClientId (string, required),
ClientProjectionFileUnits (Units, optional), DigitizationEnabled (boolean, optional), SPSEnabled (boolean, optional),
ProjectionFileAvailable (boolean, optional)               }               </example>

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetWorkOrdersListExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var getWorkOrdersListDto = new GetWorkOrdersListDto(); // GetWorkOrdersListDto | Client Information

            try
            {
                // Returns a list of available Work Orders.
                ResultDtoListWorkOrderDto result = apiInstance.WorkOrderServiceGetWorkOrdersList(getWorkOrdersListDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetWorkOrdersList: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                     | Type                                                | Description        | Notes 
--------------------------|-----------------------------------------------------|--------------------|-------
 **getWorkOrdersListDto** | [**GetWorkOrdersListDto**](GetWorkOrdersListDto.md) | Client Information |

### Return type

[**ResultDtoListWorkOrderDto**](ResultDtoListWorkOrderDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetworkorderslistandstatus"></a>

# **WorkOrderServiceGetWorkOrdersListAndStatus**

> ResultDtoValueTupleBooleanListWorkOrderDto WorkOrderServiceGetWorkOrdersListAndStatus (GetWorkOrdersListDto
> getWorkOrdersListDto)

Returns a list of available Work Orders and status if the service has finished loading all workorders in configured
directory

Lists all Work Orders - aka folders within \"Work Order Folder\" in Virtek Server Manager &gt; File Locations - subject
to the optional feature filters. If more than one of these are specified a logical AND is performed to create the result
set. To distinguish, each Work Order in the returned collection of WorkOrderDtos will have to be assessed. * *
*ClientProjectionFileUnits** - return Work Orders that use these units (see Units in Integrator's Guide)  * *
*DigitizationEnabled** - return Work Orders that use digitization; SPS only; currently unused. * **SPSENabled** - return
Work Orders that use SPS alignment not targeted/3D/FlashAlignment. * **ProjectionFileAvailable** - return Work Orders
that have valid .ply files.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetWorkOrdersListAndStatusExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var getWorkOrdersListDto = new GetWorkOrdersListDto(); // GetWorkOrdersListDto | Client Information

            try
            {
                // Returns a list of available Work Orders and status if the service has finished loading all workorders in configured directory
                ResultDtoValueTupleBooleanListWorkOrderDto result = apiInstance.WorkOrderServiceGetWorkOrdersListAndStatus(getWorkOrdersListDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceGetWorkOrdersListAndStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                     | Type                                                | Description        | Notes 
--------------------------|-----------------------------------------------------|--------------------|-------
 **getWorkOrdersListDto** | [**GetWorkOrdersListDto**](GetWorkOrdersListDto.md) | Client Information |

### Return type

[**ResultDtoValueTupleBooleanListWorkOrderDto**](ResultDtoValueTupleBooleanListWorkOrderDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderserviceloadworkorder"></a>

# **WorkOrderServiceLoadWorkOrder**

> ResultDtoString WorkOrderServiceLoadWorkOrder (LoadWorkOrderDto workOrderName)

Returns a Work Order's raw projection data.

Retrieves the contents of the named Work Order's ply file as a single string. Whitespace and EOL/CR characters are
Windows encoded (`\\t, \\r, \\n` etc.)  Does not actually load a Work Order for laser projection (see PhotoAlignment
Service  `/OpenTool`).  <example>
Units=Millimetres\\t\\t\\t\\t\\r\\nLayer\\tSTART\\tLayer1\\t\\t\\r\\nSTART\\tVirtek\\t\\t\\t\\r\\nP\\t8\\t\\t\\t\\r\\n70.445710
79.779304 0.000000\\r\\n as Units=Millimetres Layer START Layer1 START Virtek P 8 70.445710 79.779304 0.000000
*snip*                 </example>    Also see \"Iris Projection File Format Specification\", VCD-00343 for ply file
specifications.  <example>              LoadWorkOrderDto { ClientId (string, required), WorkOrderName (string,
required), ClientConfigurationProfileName (string, optional)              }              </example>

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceLoadWorkOrderExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var workOrderName = new LoadWorkOrderDto(); // LoadWorkOrderDto | Full path of a WorkOrder dir whose ply or prj file we are trying to access

            try
            {
                // Returns a Work Order's raw projection data.
                ResultDtoString result = apiInstance.WorkOrderServiceLoadWorkOrder(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceLoadWorkOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                        | Description                                                                | Notes 
-------------------|---------------------------------------------|----------------------------------------------------------------------------|-------
 **workOrderName** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | Full path of a WorkOrder dir whose ply or prj file we are trying to access |

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicevalidateselectedworkorder"></a>

# **WorkOrderServiceValidateSelectedWorkOrder**

> ResultDtoWorkOrderValidationType WorkOrderServiceValidateSelectedWorkOrder (WorkOrderNameDto selectedWorkOrder)

Performs validation checks on the specified Work Order.

Used for checking Work Order validity if if there are any problems with the Work Order, an indication of what is wrong.
See WorkOrderDto in Integrator's Guide, although when used as input most fields are ignored. Returns the following
possible values in Payload:  * `ValidWorkorder`  * `PrjFileMissing` - no longer supported; not used *
`MissingSpsLicense` - Work Order requires SPS functionality and that license is missing; not currently supported *
`BadProjectionFileFormat` - Work Order .ply file is misformed; See \"Iris Projection File Format Specification\",
VCD-00343 * `EmptyProjectionFile` - Work Order .ply file is empty/has no steps * `MultipleProcessStepsFiles` - more than
one .ply file in Work Order * `ProjectionFileWithNoDatumDefinitions` - SPS Work Order has no alignment datums defined;
not currently supported * `ExistingDigitizationWorkorderhasNoDatums` - SPS/Digitization Work Order has no alignment
datums defined; not currently supported * `DisallowDigitizingOnLocalAlignment` - SPS related; unused *
`ProjectionFileHasStepsOutsideAnyLayer` - .ply data has to be within a layer * `ProjectionFileHasNoSteps`  - .ply file
has no steps defined * `DisallowPartVerification`  - SPS related; unused * `PartVerificationPointMustHaveNormals` - SPS
related; unused * `DisallowDuplicateVerificationStepNames` - SPS related * `InvalidWorkOrderDirectory` - a Work Order
folder by the name specified does not exist in \"Work Order Directory\" (see Iris Administrator Guide &gt; Virtek
Server: File Locations

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceValidateSelectedWorkOrderExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderOperationsApi();
            var selectedWorkOrder = new WorkOrderNameDto(); // WorkOrderNameDto | 

            try
            {
                // Performs validation checks on the specified Work Order.
                ResultDtoWorkOrderValidationType result = apiInstance.WorkOrderServiceValidateSelectedWorkOrder(selectedWorkOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderOperationsApi.WorkOrderServiceValidateSelectedWorkOrder: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name                  | Type                                        | Description | Notes 
-----------------------|---------------------------------------------|-------------|-------
 **selectedWorkOrder** | [**WorkOrderNameDto**](WorkOrderNameDto.md) |             |

### Return type

[**ResultDtoWorkOrderValidationType**](ResultDtoWorkOrderValidationType.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

