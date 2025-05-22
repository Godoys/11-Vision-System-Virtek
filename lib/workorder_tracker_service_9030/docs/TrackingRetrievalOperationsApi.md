# WorkorderTrackerService.Swagger.Api.TrackingRetrievalOperationsApi

All URIs are relative to *http://localhost:9030*

Method | HTTP request | Description
------------- | ------------- | -------------
[**WorkOrderTrackerServiceGenerateProcessTrackingReport**](TrackingRetrievalOperationsApi.md#workordertrackerservicegenerateprocesstrackingreport) | **POST** /GenerateProcessTrackingReport | Generates a process report for specific Work Order projections.
[**WorkOrderTrackerServiceGetCurrentProjectionEntities**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetcurrentprojectionentities) | **POST** /GetCurrentProjectionEntities | Returns a list of Work Order steps that are open in the specified Client.
[**WorkOrderTrackerServiceGetMarkedCompleteList**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetmarkedcompletelist) | **POST** /GetMarkedCompleteList | Process Control - Returns a collection of Process Step List entities marked \&quot;complete\&quot;
[**WorkOrderTrackerServiceGetWorkOrderAccessInfo**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetworkorderaccessinfo) | **POST** /GetWorkOrderAccessInfo | Provides access history for a Work Order.
[**WorkOrderTrackerServiceGetWorkOrderEntityAccessInfo**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetworkorderentityaccessinfo) | **POST** /GetWorkOrderEntityAccessInfo | Provides access (projection) history for specific Work Order projections.
[**WorkOrderTrackerServiceGetWorkOrderInfo**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetworkorderinfo) | **POST** /GetWorkOrderInfo | Returns a list of component files (and file attributes) for the Work Order.
[**WorkOrderTrackerServiceGetWorkOrderStatus**](TrackingRetrievalOperationsApi.md#workordertrackerservicegetworkorderstatus) | **POST** /GetWorkOrderStatus | Provides information on the Client which is working with the specified Work Order.


<a name="workordertrackerservicegenerateprocesstrackingreport"></a>
# **WorkOrderTrackerServiceGenerateProcessTrackingReport**
> ResultDtoReportInfoDto WorkOrderTrackerServiceGenerateProcessTrackingReport (WorkOrderAccessRequestDto workOrderAccessRequest)

Generates a process report for specific Work Order projections.

Provides a pdf report about the Work Order: what actions TO PROCESS STEPS were performed by {client} between {startDateTime} and {endDateTime}  * **ClientID** - the Client you are auditing. If left unspecified returns all actions from all clients.  * **StartDateTime/EndDateTime** - will return those events &gt;= start and &lt;= end time; both can be specified as **null** or as an empty string (**\"\"**)  for a boundless query; use the format `YYYY-MM-DD HH:MM:SS` e.g. `2021-05-09 15:17:37`  Result OperationsType will be Start and End projection status events.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGenerateProcessTrackingReportExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderAccessRequest = new WorkOrderAccessRequestDto(); // WorkOrderAccessRequestDto | Name of the Work Order

            try
            {
                // Generates a process report for specific Work Order projections.
                ResultDtoReportInfoDto result = apiInstance.WorkOrderTrackerServiceGenerateProcessTrackingReport(workOrderAccessRequest);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGenerateProcessTrackingReport: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderAccessRequest** | [**WorkOrderAccessRequestDto**](WorkOrderAccessRequestDto.md)| Name of the Work Order | 

### Return type

[**ResultDtoReportInfoDto**](ResultDtoReportInfoDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetcurrentprojectionentities"></a>
# **WorkOrderTrackerServiceGetCurrentProjectionEntities**
> ResultDtoWorkOrderProjectionEntityCollectionDto WorkOrderTrackerServiceGetCurrentProjectionEntities (LoadWorkOrderDto workOrderDto)

Returns a list of Work Order steps that are open in the specified Client.

Returns the contents of the Work Order's Process Step List. Unlike the same information returned from Work Order Service's `/GetProjectionData` etc.  this method only returns an indication of what process steps the named client is actively projecting:  * **Status**: Active - the client is actively projecting this step/layer; Inactive - client is NOT projecting this step/layer; Paused - all Work Order projection is paused in that client.    **Note:** - does not return steps that are not in the originally opened Work Order - i.e. does not return dynamically added or \"ad-hoc\" steps added with `/AddEntities` or `/AddProjectPolygons`.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetCurrentProjectionEntitiesExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderDto = new LoadWorkOrderDto(); // LoadWorkOrderDto | workOrder information

            try
            {
                // Returns a list of Work Order steps that are open in the specified Client.
                ResultDtoWorkOrderProjectionEntityCollectionDto result = apiInstance.WorkOrderTrackerServiceGetCurrentProjectionEntities(workOrderDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetCurrentProjectionEntities: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderDto** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md)| workOrder information | 

### Return type

[**ResultDtoWorkOrderProjectionEntityCollectionDto**](ResultDtoWorkOrderProjectionEntityCollectionDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetmarkedcompletelist"></a>
# **WorkOrderTrackerServiceGetMarkedCompleteList**
> ResultDtoListProjectionEntityDto WorkOrderTrackerServiceGetMarkedCompleteList (LoadWorkOrderDto workOrder)

Process Control - Returns a collection of Process Step List entities marked \"complete\"

Returns all steps and layers, currently in the Work Order, which have been marked as complete.  This method WILL return dynamically added steps (`/AddEntity`, `/AddProjectPolygon`) if they exist,  but dynamic or ad-hoc steps (or their completion status) are not persisted in the Work Order when it is closed.    **Note** - `Id` in returned ProjectionEntityDto is the unique step identifier `EntityUniqueID`

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetMarkedCompleteListExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrder = new LoadWorkOrderDto(); // LoadWorkOrderDto | workOrder information

            try
            {
                // Process Control - Returns a collection of Process Step List entities marked \"complete\"
                ResultDtoListProjectionEntityDto result = apiInstance.WorkOrderTrackerServiceGetMarkedCompleteList(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetMarkedCompleteList: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrder** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md)| workOrder information | 

### Return type

[**ResultDtoListProjectionEntityDto**](ResultDtoListProjectionEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetworkorderaccessinfo"></a>
# **WorkOrderTrackerServiceGetWorkOrderAccessInfo**
> ResultDtoListWorkOrderAccessInfoDto WorkOrderTrackerServiceGetWorkOrderAccessInfo (WorkOrderAccessRequestDto workOrderAccessRequest)

Provides access history for a Work Order.

Provides access history for the Work Order: what actions were performed TO THE WORK ORDER by {client} between {startDateTime} and {endDateTime}  * **ClientID** - the Client you are auditing. If left unspecified returns all actions from all clients.  * **StartDateTime/EndDateTime** - will return those events &gt;= start and &lt;= end time; both can be specified as **null** or as an empty string (**\"\"**)  for a boundless query; use the format `YYYY-MM-DD HH:MM:SS` e.g. `2021-05-09 15:17:37`  Result OperationsType will be Open/Close Work Order events, alignment events.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetWorkOrderAccessInfoExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderAccessRequest = new WorkOrderAccessRequestDto(); // WorkOrderAccessRequestDto | Name of the Work Order

            try
            {
                // Provides access history for a Work Order.
                ResultDtoListWorkOrderAccessInfoDto result = apiInstance.WorkOrderTrackerServiceGetWorkOrderAccessInfo(workOrderAccessRequest);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetWorkOrderAccessInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderAccessRequest** | [**WorkOrderAccessRequestDto**](WorkOrderAccessRequestDto.md)| Name of the Work Order | 

### Return type

[**ResultDtoListWorkOrderAccessInfoDto**](ResultDtoListWorkOrderAccessInfoDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetworkorderentityaccessinfo"></a>
# **WorkOrderTrackerServiceGetWorkOrderEntityAccessInfo**
> ResultDtoListWorkOrderEntityAccessInfoDto WorkOrderTrackerServiceGetWorkOrderEntityAccessInfo (WorkOrderAccessRequestDto workOrderAccessRequest)

Provides access (projection) history for specific Work Order projections.

Provides a query into the Work Order: what actions TO PROCESS STEPS were performed by {client} between {startDateTime} and {endDateTime}  * **ClientID** - the Client you are auditing. If left unspecified returns all actions from all clients.  * **StartDateTime/EndDateTime** - will return those events &gt;= start and &lt;= end time; both can be specified as **null** or as an empty string (**\"\"**)  for a boundless query; use the format `YYYY-MM-DD HH:MM:SS` e.g. `2021-05-09 15:17:37`  Result OperationsType will be Start and End projection status events.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetWorkOrderEntityAccessInfoExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderAccessRequest = new WorkOrderAccessRequestDto(); // WorkOrderAccessRequestDto | Name of the Work Order

            try
            {
                // Provides access (projection) history for specific Work Order projections.
                ResultDtoListWorkOrderEntityAccessInfoDto result = apiInstance.WorkOrderTrackerServiceGetWorkOrderEntityAccessInfo(workOrderAccessRequest);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetWorkOrderEntityAccessInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderAccessRequest** | [**WorkOrderAccessRequestDto**](WorkOrderAccessRequestDto.md)| Name of the Work Order | 

### Return type

[**ResultDtoListWorkOrderEntityAccessInfoDto**](ResultDtoListWorkOrderEntityAccessInfoDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetworkorderinfo"></a>
# **WorkOrderTrackerServiceGetWorkOrderInfo**
> ResultDtoWorkOrderDataDto WorkOrderTrackerServiceGetWorkOrderInfo (WorkOrderNameDto workOrderDto)

Returns a list of component files (and file attributes) for the Work Order.

See \"Work Order File Management\" in the Iris Administrator Guide for an overview of Work Order files.  * **FileStatus** - Inactive/Active - for some filetypes (projection and targets files) where Shortcuts are possible, this gives an indication of whether this file is actively being used for Work Order alignment or projection/Process Step information.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetWorkOrderInfoExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderDto = new WorkOrderNameDto(); // WorkOrderNameDto | 

            try
            {
                // Returns a list of component files (and file attributes) for the Work Order.
                ResultDtoWorkOrderDataDto result = apiInstance.WorkOrderTrackerServiceGetWorkOrderInfo(workOrderDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetWorkOrderInfo: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderDto** | [**WorkOrderNameDto**](WorkOrderNameDto.md)|  | 

### Return type

[**ResultDtoWorkOrderDataDto**](ResultDtoWorkOrderDataDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerservicegetworkorderstatus"></a>
# **WorkOrderTrackerServiceGetWorkOrderStatus**
> ResultDtoListWorkOrderStatusDto WorkOrderTrackerServiceGetWorkOrderStatus (WorkOrderNameDto workOrderDto)

Provides information on the Client which is working with the specified Work Order.

Also specifies the Work Cell specified when opening the Work Order (if applicable)

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceGetWorkOrderStatusExample
    {
        public void main()
        {
            var apiInstance = new TrackingRetrievalOperationsApi();
            var workOrderDto = new WorkOrderNameDto(); // WorkOrderNameDto | 

            try
            {
                // Provides information on the Client which is working with the specified Work Order.
                ResultDtoListWorkOrderStatusDto result = apiInstance.WorkOrderTrackerServiceGetWorkOrderStatus(workOrderDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingRetrievalOperationsApi.WorkOrderTrackerServiceGetWorkOrderStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderDto** | [**WorkOrderNameDto**](WorkOrderNameDto.md)|  | 

### Return type

[**ResultDtoListWorkOrderStatusDto**](ResultDtoListWorkOrderStatusDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

