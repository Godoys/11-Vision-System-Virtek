# WorkorderService.Swagger.Api.WorkOrderTrackingOperationsApi

All URIs are relative to *http://localhost:9020*

Method | HTTP request | Description
------------- | ------------- | -------------
[**WorkOrderServiceUpdateProcessEntitiesCompletenessStatus**](WorkOrderTrackingOperationsApi.md#workorderserviceupdateprocessentitiescompletenessstatus) | **POST** /UpdateProcessEntitiesCompletenessStatus | Process Control - Sets the \&quot;complete\&quot; or \&quot;incomplete\&quot; status of a collection of Process Step List entities by EntityID.


<a name="workorderserviceupdateprocessentitiescompletenessstatus"></a>
# **WorkOrderServiceUpdateProcessEntitiesCompletenessStatus**
> ResultDtoBoolean WorkOrderServiceUpdateProcessEntitiesCompletenessStatus (UpdateProcessEntitiesCompletenessDto entityDtos)

Process Control - Sets the \"complete\" or \"incomplete\" status of a collection of Process Step List entities by EntityID.

Sets the \"complete\" or `IsMarkComplete` flag on the projection entities passed via collection, specified  by unique EntityID   Entities with IsMarkComplete=true will be returned by `GetMarkedCompleteList`.    Note that this endpoint specifies just the Entities you want to change, and you can specify different `IsMarkComplete`  values for each entity (i.e. this endpoint doesn't set or toggle them all the same).     * **ProjectionEntityStatus**: List of entities (layers/steps) that need to be updated. Each entity requires `ID` (EntityID) and `IsMarkComplete` (true/false) - any entity Names specified will be ignored.   * **OperationType**: \"MarkComplete\" or \"MarkIncomplete\" - this is the action that the WorkOrderTracker service will write into the Work Order database/log; this has no correlation to the `IsMarkComplete` value specified for each entity.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceUpdateProcessEntitiesCompletenessStatusExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderTrackingOperationsApi();
            var entityDtos = new UpdateProcessEntitiesCompletenessDto(); // UpdateProcessEntitiesCompletenessDto | entity Mark complete status list

            try
            {
                // Process Control - Sets the \"complete\" or \"incomplete\" status of a collection of Process Step List entities by EntityID.
                ResultDtoBoolean result = apiInstance.WorkOrderServiceUpdateProcessEntitiesCompletenessStatus(entityDtos);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderTrackingOperationsApi.WorkOrderServiceUpdateProcessEntitiesCompletenessStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entityDtos** | [**UpdateProcessEntitiesCompletenessDto**](UpdateProcessEntitiesCompletenessDto.md)| entity Mark complete status list | 

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

