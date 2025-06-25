# WorkorderTrackerService.Swagger.Api.TrackingOperationsApi

All URIs are relative to *http://localhost:9030*

 Method                                                                                                                                                        | HTTP request                                      | Description                                                                                                                                                                                 
---------------------------------------------------------------------------------------------------------------------------------------------------------------|---------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 [**WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatus**](TrackingOperationsApi.md#workordertrackerserviceupdateprocessentitiescompletenessstatus) | **POST** /UpdateProcessEntitiesCompletenessStatus | Process Control - Sets the \&quot;complete\&quot; or \&quot;incomplete\&quot; status of a collection of Process Step List entities by EntityID.                                             
 [**WorkOrderTrackerServiceUpdateProjectionEntitiesHistory**](TrackingOperationsApi.md#workordertrackerserviceupdateprojectionentitieshistory)                 | **POST** /UpdateProjectionEntitiesHistory         | Tracking - Sets the  Operation of a collection of Process Step List entities by name (StartProjection, EndProjection, PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete).     
 [**WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryById**](TrackingOperationsApi.md#workordertrackerserviceupdateprojectionentitieshistorybyid)         | **POST** /UpdateProjectionEntitiesHistoryById     | Tracking - Sets the  Operation of a collection of Process Step List entities by EntityID (StartProjection, EndProjection, PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete). 

<a name="workordertrackerserviceupdateprocessentitiescompletenessstatus"></a>

# **WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatus**

> ResultDtoBoolean WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatus (UpdateProcessEntitiesCompletenessDto
> entityDtos)

Process Control - Sets the \"complete\" or \"incomplete\" status of a collection of Process Step List entities by
EntityID.

Sets the \"complete\" or `IsMarkComplete` flag on the projection entities passed via collection, specified by unique
EntityID Entities with IsMarkComplete=true will be returned by `GetMarkedCompleteList`. Note that this endpoint
specifies just the Entities you want to change, and you can specify different `IsMarkComplete`  values for each entity (
i.e. this endpoint doesn't set or toggle them all the same). * **ProjectionEntityStatus**: List of entities (
layers/steps) that need to be updated. Each entity requires `ID` (EntityID) and `IsMarkComplete` (true/false) - **any
entity Names specified will be ignored**. * **OperationType**: \"MarkComplete\" or \"MarkIncomplete\" - this is the
action that the WorkOrderTracker service will write into the Work Order database/log; this has no correlation to the
`IsMarkComplete` value specified for each entity.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatusExample
    {
        public void main()
        {
            var apiInstance = new TrackingOperationsApi();
            var entityDtos = new UpdateProcessEntitiesCompletenessDto(); // UpdateProcessEntitiesCompletenessDto | entity Mark complete status list

            try
            {
                // Process Control - Sets the \"complete\" or \"incomplete\" status of a collection of Process Step List entities by EntityID.
                ResultDtoBoolean result = apiInstance.WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatus(entityDtos);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingOperationsApi.WorkOrderTrackerServiceUpdateProcessEntitiesCompletenessStatus: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                                                                | Description                      | Notes 
----------------|-------------------------------------------------------------------------------------|----------------------------------|-------
 **entityDtos** | [**UpdateProcessEntitiesCompletenessDto**](UpdateProcessEntitiesCompletenessDto.md) | entity Mark complete status list |

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerserviceupdateprojectionentitieshistory"></a>

# **WorkOrderTrackerServiceUpdateProjectionEntitiesHistory**

> ResultDtoBoolean WorkOrderTrackerServiceUpdateProjectionEntitiesHistory (ProjectionEntityStatusCollectionDto
> entitiesStatus)

Tracking - Sets the Operation of a collection of Process Step List entities by name (StartProjection, EndProjection,
PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete).

Sets the Operation Type on the projection entities passed via collection, specified by NAME (not necessarily unique).
Note that this endpoint specifies just the Entities you want to change. values for each entity (i.e. this endpoint
doesn't set or toggle them all the same).  **Note** - If the specified Entity name is not unique in the Work Order then
the first one found with that name will be set with the specified Operation Type value.  (to be more specific, use
`UpdateProjectionEntitiesHistoryById` below.)    * **ProjectionEntityStatus**: List of entities (layers/steps) that need
to be updated. Each entity requires `Name` - any IDs specified will be ignored * **OperationType**: \"StartProjection\",
\"EndProjection\", \"PauseProjection\", \"ResumeProjection\", \"MarkComplete\", \"MarkIncomplete\" - this is the action
that the WorkOrderTracker service will write into the Work Order database/log;.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryExample
    {
        public void main()
        {
            var apiInstance = new TrackingOperationsApi();
            var entitiesStatus = new ProjectionEntityStatusCollectionDto(); // ProjectionEntityStatusCollectionDto | 

            try
            {
                // Tracking - Sets the  Operation of a collection of Process Step List entities by name (StartProjection, EndProjection, PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete).
                ResultDtoBoolean result = apiInstance.WorkOrderTrackerServiceUpdateProjectionEntitiesHistory(entitiesStatus);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingOperationsApi.WorkOrderTrackerServiceUpdateProjectionEntitiesHistory: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name               | Type                                                                              | Description | Notes 
--------------------|-----------------------------------------------------------------------------------|-------------|-------
 **entitiesStatus** | [**ProjectionEntityStatusCollectionDto**](ProjectionEntityStatusCollectionDto.md) |             |

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workordertrackerserviceupdateprojectionentitieshistorybyid"></a>

# **WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryById**

> ResultDtoBoolean WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryById (ProjectionEntityStatusCollectionDto
> entitiesStatus)

Tracking - Sets the Operation of a collection of Process Step List entities by EntityID (StartProjection, EndProjection,
PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete).

Sets the Operation Type on the projection entities passed via collection, specified by ID. Note that this endpoint
specifies just the Entities you want to change. values for each entity (i.e. this endpoint doesn't set or toggle them
all the same).  **Note** - If the specified Entity name is not unique in the Work Order then the first one found with
that name will be set with the specified Operation Type value.  (to be more specific, use
`UpdateProjectionEntitiesHistoryById` below.)    * **ProjectionEntityStatus**: List of entities (layers/steps) that need
to be updated. Each entity requires `ID` (EntityID) - **any entity Names specified will be ignored**. * **OperationType
**: \"StartProjection\", \"EndProjection\", \"PauseProjection\", \"ResumeProjection\", \"MarkComplete\",
\"MarkIncomplete\" - this is the action that the WorkOrderTracker service will write into the Work Order database/log;.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderTrackerService.Swagger.Api;
using WorkorderTrackerService.Swagger.Client;
using WorkorderTrackerService.Swagger.Model;

namespace Example
{
    public class WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryByIdExample
    {
        public void main()
        {
            var apiInstance = new TrackingOperationsApi();
            var entitiesStatus = new ProjectionEntityStatusCollectionDto(); // ProjectionEntityStatusCollectionDto | 

            try
            {
                // Tracking - Sets the  Operation of a collection of Process Step List entities by EntityID (StartProjection, EndProjection, PauseProjection, ResumeProjection, MarkComplete, MarkIncomplete).
                ResultDtoBoolean result = apiInstance.WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryById(entitiesStatus);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling TrackingOperationsApi.WorkOrderTrackerServiceUpdateProjectionEntitiesHistoryById: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name               | Type                                                                              | Description | Notes 
--------------------|-----------------------------------------------------------------------------------|-------------|-------
 **entitiesStatus** | [**ProjectionEntityStatusCollectionDto**](ProjectionEntityStatusCollectionDto.md) |             |

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

