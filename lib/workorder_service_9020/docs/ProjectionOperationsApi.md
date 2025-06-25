# WorkorderService.Swagger.Api.ProjectionOperationsApi

All URIs are relative to *http://localhost:9020*

 Method                                                                                                                                        | HTTP request                                    | Description                                                                                                                                                                                                                     
-----------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
 [**WorkOrderServiceGetFirstProjectionStep**](ProjectionOperationsApi.md#workorderservicegetfirstprojectionstep)                               | **POST** /GetFirstProjectionStep                | Returns the first or \&quot;top\&quot; projection step in the Work Order&#39;s Process Step List.                                                                                                                               
 [**WorkOrderServiceGetLastAccessedProjectionEntities**](ProjectionOperationsApi.md#workorderservicegetlastaccessedprojectionentities)         | **POST** /GetLastAccessedProjectionEntities     | Get the list of projection entity NAMES that were last accessed by the Work Order                                                                                                                                               
 [**WorkOrderServiceGetLastAccessedProjectionEntitiesById**](ProjectionOperationsApi.md#workorderservicegetlastaccessedprojectionentitiesbyid) | **POST** /GetLastAccessedProjectionEntitiesById | Get the list of projection entity IDs that were last accessed by the Work Order                                                                                                                                                 
 [**WorkOrderServiceGetLastProjectionStep**](ProjectionOperationsApi.md#workorderservicegetlastprojectionstep)                                 | **POST** /GetLastProjectionStep                 | Returns the last or \&quot;bottom\&quot; projection step in the Work Order&#39;s Process Step List.                                                                                                                             
 [**WorkOrderServiceGetMarkedCompleteList**](ProjectionOperationsApi.md#workorderservicegetmarkedcompletelist)                                 | **POST** /GetMarkedCompleteList                 | Process Control - Returns a collection of Process Step List entities marked \&quot;complete\&quot;                                                                                                                              
 [**WorkOrderServiceGetNextDefaultWorkOrderName**](ProjectionOperationsApi.md#workorderservicegetnextdefaultworkordername)                     | **POST** /GetNextDefaultWorkOrderName           | Get the next available work order name under the parent folder provided, return empty if the parent folder is invalid                                                                                                           
 [**WorkOrderServiceGetNextProjectionStep**](ProjectionOperationsApi.md#workorderservicegetnextprojectionstep)                                 | **POST** /GetNextProjectionStep                 | Returns the \&quot;next\&quot; (down) projection step; if the current step is the last step, returns the current step.                                                                                                          
 [**WorkOrderServiceGetPreviousProjectionStep**](ProjectionOperationsApi.md#workorderservicegetpreviousprojectionstep)                         | **POST** /GetPreviousProjectionStep             | Returns the \&quot;previous\&quot; (up) projection step; if the current step is the first step, returns the current step.                                                                                                       
 [**WorkOrderServiceGetProjectionData**](ProjectionOperationsApi.md#workorderservicegetprojectiondata)                                         | **POST** /GetProjectionData                     | Returns process steps by NAME from the Work Order.                                                                                                                                                                              
 [**WorkOrderServiceGetProjectionDataWithIds**](ProjectionOperationsApi.md#workorderservicegetprojectiondatawithids)                           | **POST** /GetProjectionDataWithIds              | Returns process steps by ID from the Work Order.                                                                                                                                                                                
 [**WorkOrderServiceGetProjectionEntityByFullName**](ProjectionOperationsApi.md#workorderservicegetprojectionentitybyfullname)                 | **POST** /GetProjectionEntityByFullName         | Get and return the projection data with it&#39;s full name (path + name, i.e. layer\\step)  if the name is a layer, all the steps in that layer will be returned.  If multiple names exist, only the first one will be returned 
 [**WorkOrderServiceGetProjectionEntityById**](ProjectionOperationsApi.md#workorderservicegetprojectionentitybyid)                             | **POST** /GetProjectionEntityById               | Get and return the projection data of the step with ID specified, or all the steps contained under the layer of the ID                                                                                                          
 [**WorkOrderServiceGetProjectionStepNames**](ProjectionOperationsApi.md#workorderservicegetprojectionstepnames)                               | **POST** /GetProjectionStepNames                | Returns a flattened list of Work Order process steps.                                                                                                                                                                           
 [**WorkOrderServiceLoadProjectionEntitiesFromContent**](ProjectionOperationsApi.md#workorderserviceloadprojectionentitiesfromcontent)         | **POST** /LoadProjectionEntitiesFromContent     | Parse and load the projection entities from the data content                                                                                                                                                                    
 [**WorkOrderServiceLoadTargetDataFromContent**](ProjectionOperationsApi.md#workorderserviceloadtargetdatafromcontent)                         | **POST** /LoadTargetDataFromContent             | Parse and load the target from the data content                                                                                                                                                                                 
 [**WorkOrderServiceSaveWorkOrderData**](ProjectionOperationsApi.md#workorderservicesaveworkorderdata)                                         | **POST** /SaveWorkOrderData                     | Save the new.modified data content to the files of the work order                                                                                                                                                               
 [**WorkOrderServiceSetCurrentProjectionSteps**](ProjectionOperationsApi.md#workorderservicesetcurrentprojectionsteps)                         | **POST** /SetCurrentProjectionSteps             | Selects a range of process steps by NAME from the Work order&#39;s list and projects them.                                                                                                                                      
 [**WorkOrderServiceSetCurrentProjectionStepsWithId**](ProjectionOperationsApi.md#workorderservicesetcurrentprojectionstepswithid)             | **POST** /SetCurrentProjectionStepsWithId       | Selects a range of process steps by ID from the Work order&#39;s list and projects them.                                                                                                                                        

<a name="workorderservicegetfirstprojectionstep"></a>

# **WorkOrderServiceGetFirstProjectionStep**

> ResultDtoEntityDto WorkOrderServiceGetFirstProjectionStep (LoadWorkOrderDto workOrderName)

Returns the first or \"top\" projection step in the Work Order's Process Step List.

**ClientConfigurationProfileName** - An optional parameter. A configuration profile name to identify which configuration
profile the server will use to load work order files. Server will use the client baseline default configuration values
if this parameter is empty.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetFirstProjectionStepExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrderName = new LoadWorkOrderDto(); // LoadWorkOrderDto | Work order name and the client id

            try
            {
                // Returns the first or \"top\" projection step in the Work Order's Process Step List.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetFirstProjectionStep(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetFirstProjectionStep: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                        | Description                       | Notes 
-------------------|---------------------------------------------|-----------------------------------|-------
 **workOrderName** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | Work order name and the client id |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetlastaccessedprojectionentities"></a>

# **WorkOrderServiceGetLastAccessedProjectionEntities**

> ResultDtoListString WorkOrderServiceGetLastAccessedProjectionEntities (LoadWorkOrderDto workOrder)

Get the list of projection entity NAMES that were last accessed by the Work Order

Returns a list of step NAMES that have most recently been accessed in the Work Order; either selected or projected (
since these will frequently be the same)  To return the same list but with EntityUniqueId, see
`/GetLastAccessedProjectionEntitiesById`.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetLastAccessedProjectionEntitiesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrder = new LoadWorkOrderDto(); // LoadWorkOrderDto | workOrder information

            try
            {
                // Get the list of projection entity NAMES that were last accessed by the Work Order
                ResultDtoListString result = apiInstance.WorkOrderServiceGetLastAccessedProjectionEntities(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetLastAccessedProjectionEntities: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type                                        | Description           | Notes 
---------------|---------------------------------------------|-----------------------|-------
 **workOrder** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | workOrder information |

### Return type

[**ResultDtoListString**](ResultDtoListString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetlastaccessedprojectionentitiesbyid"></a>

# **WorkOrderServiceGetLastAccessedProjectionEntitiesById**

> ResultDtoListInt32 WorkOrderServiceGetLastAccessedProjectionEntitiesById (LoadWorkOrderDto workOrder)

Get the list of projection entity IDs that were last accessed by the Work Order

Returns a list of step `EntityUniqueID` that have most recently been accessed in the Work Order; either selected or
projected (since these will frequently be the same)  To return the same list but with step NAMES, see
`/GetLastAccessedProjectionEntities`.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetLastAccessedProjectionEntitiesByIdExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrder = new LoadWorkOrderDto(); // LoadWorkOrderDto | workOrder information

            try
            {
                // Get the list of projection entity IDs that were last accessed by the Work Order
                ResultDtoListInt32 result = apiInstance.WorkOrderServiceGetLastAccessedProjectionEntitiesById(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetLastAccessedProjectionEntitiesById: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type                                        | Description           | Notes 
---------------|---------------------------------------------|-----------------------|-------
 **workOrder** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | workOrder information |

### Return type

[**ResultDtoListInt32**](ResultDtoListInt32.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetlastprojectionstep"></a>

# **WorkOrderServiceGetLastProjectionStep**

> ResultDtoEntityDto WorkOrderServiceGetLastProjectionStep (LoadWorkOrderDto workOrderName)

Returns the last or \"bottom\" projection step in the Work Order's Process Step List.

**ClientConfigurationProfileName** - An optional parameter. A configuration profile name to identify which configuration
profile the server will use to load work order files. Server will use the client baseline default configuration values
if this parameter is empty.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetLastProjectionStepExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrderName = new LoadWorkOrderDto(); // LoadWorkOrderDto | Work order name and the client id

            try
            {
                // Returns the last or \"bottom\" projection step in the Work Order's Process Step List.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetLastProjectionStep(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetLastProjectionStep: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                        | Description                       | Notes 
-------------------|---------------------------------------------|-----------------------------------|-------
 **workOrderName** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | Work order name and the client id |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetmarkedcompletelist"></a>

# **WorkOrderServiceGetMarkedCompleteList**

> ResultDtoListProjectionEntityDto WorkOrderServiceGetMarkedCompleteList (LoadWorkOrderDto workOrder)

Process Control - Returns a collection of Process Step List entities marked \"complete\"

Returns all steps and layers, currently in the Work Order, which have been marked as complete. This method WILL return
dynamically added steps (`/AddEntity`, `/AddProjectPolygon`) if they exist, but dynamic or ad-hoc steps (or their
completion status) are not persisted in the Work Order when it is closed.    **Note** - `Id` in returned
ProjectionEntityDto is the unique step identifier `EntityUniqueID`

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetMarkedCompleteListExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrder = new LoadWorkOrderDto(); // LoadWorkOrderDto | workOrder information

            try
            {
                // Process Control - Returns a collection of Process Step List entities marked \"complete\"
                ResultDtoListProjectionEntityDto result = apiInstance.WorkOrderServiceGetMarkedCompleteList(workOrder);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetMarkedCompleteList: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name          | Type                                        | Description           | Notes 
---------------|---------------------------------------------|-----------------------|-------
 **workOrder** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | workOrder information |

### Return type

[**ResultDtoListProjectionEntityDto**](ResultDtoListProjectionEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetnextdefaultworkordername"></a>

# **WorkOrderServiceGetNextDefaultWorkOrderName**

> ResultDtoNewWorkOrdeNameDto WorkOrderServiceGetNextDefaultWorkOrderName (GetNewWorkOrdeNameDto getNameDto)

Get the next available work order name under the parent folder provided, return empty if the parent folder is invalid

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetNextDefaultWorkOrderNameExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var getNameDto = new GetNewWorkOrdeNameDto(); // GetNewWorkOrdeNameDto | 

            try
            {
                // Get the next available work order name under the parent folder provided, return empty if the parent folder is invalid
                ResultDtoNewWorkOrdeNameDto result = apiInstance.WorkOrderServiceGetNextDefaultWorkOrderName(getNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetNextDefaultWorkOrderName: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                                  | Description | Notes 
----------------|-------------------------------------------------------|-------------|-------
 **getNameDto** | [**GetNewWorkOrdeNameDto**](GetNewWorkOrdeNameDto.md) |             |

### Return type

[**ResultDtoNewWorkOrdeNameDto**](ResultDtoNewWorkOrdeNameDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetnextprojectionstep"></a>

# **WorkOrderServiceGetNextProjectionStep**

> ResultDtoEntityDto WorkOrderServiceGetNextProjectionStep (ClientIdDto clientId)

Returns the \"next\" (down) projection step; if the current step is the last step, returns the current step.

Note that this doesn't actually change the selection in the Process Step List, or actually perform a \"Next\" action. If
there is a multiple selection active, the \"next\" step is the one below the lowest in selection.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetNextProjectionStepExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var clientId = new ClientIdDto(); // ClientIdDto | client id

            try
            {
                // Returns the \"next\" (down) projection step; if the current step is the last step, returns the current step.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetNextProjectionStep(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetNextProjectionStep: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) | client id   |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetpreviousprojectionstep"></a>

# **WorkOrderServiceGetPreviousProjectionStep**

> ResultDtoEntityDto WorkOrderServiceGetPreviousProjectionStep (ClientIdDto clientId)

Returns the \"previous\" (up) projection step; if the current step is the first step, returns the current step.

Note that this doesn't actually change the selection in the Process Step List, or actually perform a \"Previous\"
action. If there is a multiple selection active, the \"previous\" step is the one above the highest in the selection.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetPreviousProjectionStepExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var clientId = new ClientIdDto(); // ClientIdDto | client id

            try
            {
                // Returns the \"previous\" (up) projection step; if the current step is the first step, returns the current step.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetPreviousProjectionStep(clientId);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetPreviousProjectionStep: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name         | Type                              | Description | Notes 
--------------|-----------------------------------|-------------|-------
 **clientId** | [**ClientIdDto**](ClientIdDto.md) | client id   |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetprojectiondata"></a>

# **WorkOrderServiceGetProjectionData**

> ResultDtoEntityDto WorkOrderServiceGetProjectionData (GetProjectionDataDto getPlyDataDto)

Returns process steps by NAME from the Work Order.

Returns the specified projection steps - by Name (`PlyNames`) - from the Work Order as EntityDtos (see Integrator's
Guide)    * **WorkOrderName** - The requested work order folder name to load the projection data file. If there is an
opened work order, this parameter will be ignored. * **PlyNames** - array of named process steps to retrieve. If
omitted, specified as `null`, or an empty array (`\"PlyNames\": []`) is used, the entire Process Step List (entire
projection/`.ply` file) is retrieved. * **ClientConfigurationProfileName** - An optional parameter. A configuration
profile name to identify which configuration profile the server will use to load work order files. Server will use the
client baseline default configuration values if this parameter is empty.    **Note:** The EntityDto structures returned
by this call will contain both step name (`EntityID`) and EntityUniqueID (`UniqueEntityId`), **however the
EntityUniqueIDs will all be `0`**. To obtain EntityUniqueIDs for steps and layers, use
`/GetProjectionDataWithIds`.  <example>               GetProjectionDataDto { ClientId (string, required),
WorkOrderName (string, required), PlyNames (Array[string], optional), ClientConfigurationProfileName (string,
optional)               }               </example>

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetProjectionDataExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var getPlyDataDto = new GetProjectionDataDto(); // GetProjectionDataDto | 

            try
            {
                // Returns process steps by NAME from the Work Order.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetProjectionData(getPlyDataDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetProjectionData: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                                | Description | Notes 
-------------------|-----------------------------------------------------|-------------|-------
 **getPlyDataDto** | [**GetProjectionDataDto**](GetProjectionDataDto.md) |             |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetprojectiondatawithids"></a>

# **WorkOrderServiceGetProjectionDataWithIds**

> ResultDtoEntityDto WorkOrderServiceGetProjectionDataWithIds (GetProjectionDataWithIdDto getPlyDataDto)

Returns process steps by ID from the Work Order.

Returns the specified process steps - by `EntityUniqueId` aka `PlyIds` - from the Work Order as EntityDtos (see
Integrator's Guide)    * **WorkOrderName** - The requested work order folder name to load the projection data file. If
there is an opened work order, this parameter will be ignored. * **PlyIds** - array of unique process steps
identifiers (`EntityUniqueId`) to retrieve; if empty the entire Process Step List (entire projection/`.ply` file) is
returned. * **ClientConfigurationProfileName** - An optional parameter. A configuration profile name to identify which
configuration profile the server will use to load work order files. Server will use the client baseline default
configuration values if this parameter is empty.    **Note:** The EntityDto structures returned by this call will
contain both step name (`EntityName`) and EntityUniqueId (`EntityUniqueId`).  **EntityActions:** A list of entity
actions the step contains that can be any of the following types:   Query, CountDownTimer, Info, Text, Graphics. It can
also contain some types that Iris does not support currently, but will be supported in the future those include: Led,
PolyMarker, Verification and so on A step could have multiple actions, but should only contain one action for each type.
If more than one is included of the same type the actions will be handled differently depend on the type, such as Query
and Info text will be merged into one and graphics will be displayed in multiple windows  **Note:** Query action is
required stand alone, i.e. if a step contains Query, it should not contain any other actions. If other actions found,
they will be ignored.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetProjectionDataWithIdsExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var getPlyDataDto = new GetProjectionDataWithIdDto(); // GetProjectionDataWithIdDto | 

            try
            {
                // Returns process steps by ID from the Work Order.
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceGetProjectionDataWithIds(getPlyDataDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetProjectionDataWithIds: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                                            | Description | Notes 
-------------------|-----------------------------------------------------------------|-------------|-------
 **getPlyDataDto** | [**GetProjectionDataWithIdDto**](GetProjectionDataWithIdDto.md) |             |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetprojectionentitybyfullname"></a>

# **WorkOrderServiceGetProjectionEntityByFullName**

> ResultDtoProjectionEntityDataDto WorkOrderServiceGetProjectionEntityByFullName (ProjectEntityWithFullNameDto
> fullNameDto)

Get and return the projection data with it's full name (path + name, i.e. layer\\step)  if the name is a layer, all the
steps in that layer will be returned. If multiple names exist, only the first one will be returned

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetProjectionEntityByFullNameExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var fullNameDto = new ProjectEntityWithFullNameDto(); // ProjectEntityWithFullNameDto | the data object that specifies the full name of the entity to be retrieved

            try
            {
                // Get and return the projection data with it's full name (path + name, i.e. layer\\step)  if the name is a layer, all the steps in that layer will be returned.  If multiple names exist, only the first one will be returned
                ResultDtoProjectionEntityDataDto result = apiInstance.WorkOrderServiceGetProjectionEntityByFullName(fullNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetProjectionEntityByFullName: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                                                                | Description                                                                | Notes 
-----------------|---------------------------------------------------------------------|----------------------------------------------------------------------------|-------
 **fullNameDto** | [**ProjectEntityWithFullNameDto**](ProjectEntityWithFullNameDto.md) | the data object that specifies the full name of the entity to be retrieved |

### Return type

[**ResultDtoProjectionEntityDataDto**](ResultDtoProjectionEntityDataDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetprojectionentitybyid"></a>

# **WorkOrderServiceGetProjectionEntityById**

> ResultDtoProjectionEntityDataDto WorkOrderServiceGetProjectionEntityById (ProjectEntityWithFullNameDto fullNameDto)

Get and return the projection data of the step with ID specified, or all the steps contained under the layer of the ID

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetProjectionEntityByIdExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var fullNameDto = new ProjectEntityWithFullNameDto(); // ProjectEntityWithFullNameDto | the data object that specifies the full name of the entity to be retrieved

            try
            {
                // Get and return the projection data of the step with ID specified, or all the steps contained under the layer of the ID
                ResultDtoProjectionEntityDataDto result = apiInstance.WorkOrderServiceGetProjectionEntityById(fullNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetProjectionEntityById: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                                                                | Description                                                                | Notes 
-----------------|---------------------------------------------------------------------|----------------------------------------------------------------------------|-------
 **fullNameDto** | [**ProjectEntityWithFullNameDto**](ProjectEntityWithFullNameDto.md) | the data object that specifies the full name of the entity to be retrieved |

### Return type

[**ResultDtoProjectionEntityDataDto**](ResultDtoProjectionEntityDataDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicegetprojectionstepnames"></a>

# **WorkOrderServiceGetProjectionStepNames**

> ResultDtoString WorkOrderServiceGetProjectionStepNames (LoadWorkOrderDto workOrderName)

Returns a flattened list of Work Order process steps.

Provides a list of the specified Work Order's process steps, top to bottom. Unlike the Process Step List in Iris Client,
layers are ignored and not returned in this list.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceGetProjectionStepNamesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var workOrderName = new LoadWorkOrderDto(); // LoadWorkOrderDto | Work order name and the client id

            try
            {
                // Returns a flattened list of Work Order process steps.
                ResultDtoString result = apiInstance.WorkOrderServiceGetProjectionStepNames(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceGetProjectionStepNames: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name              | Type                                        | Description                       | Notes 
-------------------|---------------------------------------------|-----------------------------------|-------
 **workOrderName** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md) | Work order name and the client id |

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderserviceloadprojectionentitiesfromcontent"></a>

# **WorkOrderServiceLoadProjectionEntitiesFromContent**

> ResultDtoEntityDto WorkOrderServiceLoadProjectionEntitiesFromContent (WorkOrderFileContentDto dataContent)

Parse and load the projection entities from the data content

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceLoadProjectionEntitiesFromContentExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var dataContent = new WorkOrderFileContentDto(); // WorkOrderFileContentDto | the ply file content

            try
            {
                // Parse and load the projection entities from the data content
                ResultDtoEntityDto result = apiInstance.WorkOrderServiceLoadProjectionEntitiesFromContent(dataContent);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceLoadProjectionEntitiesFromContent: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                                                      | Description          | Notes 
-----------------|-----------------------------------------------------------|----------------------|-------
 **dataContent** | [**WorkOrderFileContentDto**](WorkOrderFileContentDto.md) | the ply file content |

### Return type

[**ResultDtoEntityDto**](ResultDtoEntityDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderserviceloadtargetdatafromcontent"></a>

# **WorkOrderServiceLoadTargetDataFromContent**

> ResultDtoTargetDataDto WorkOrderServiceLoadTargetDataFromContent (WorkOrderFileContentDto dataContent)

Parse and load the target from the data content

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceLoadTargetDataFromContentExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var dataContent = new WorkOrderFileContentDto(); // WorkOrderFileContentDto | the cal file content

            try
            {
                // Parse and load the target from the data content
                ResultDtoTargetDataDto result = apiInstance.WorkOrderServiceLoadTargetDataFromContent(dataContent);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceLoadTargetDataFromContent: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                                                      | Description          | Notes 
-----------------|-----------------------------------------------------------|----------------------|-------
 **dataContent** | [**WorkOrderFileContentDto**](WorkOrderFileContentDto.md) | the cal file content |

### Return type

[**ResultDtoTargetDataDto**](ResultDtoTargetDataDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicesaveworkorderdata"></a>

# **WorkOrderServiceSaveWorkOrderData**

> ResultDto WorkOrderServiceSaveWorkOrderData (WorkOrderSaveDataDto dataContent)

Save the new.modified data content to the files of the work order

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceSaveWorkOrderDataExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var dataContent = new WorkOrderSaveDataDto(); // WorkOrderSaveDataDto | 

            try
            {
                // Save the new.modified data content to the files of the work order
                ResultDto result = apiInstance.WorkOrderServiceSaveWorkOrderData(dataContent);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceSaveWorkOrderData: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name            | Type                                                | Description | Notes 
-----------------|-----------------------------------------------------|-------------|-------
 **dataContent** | [**WorkOrderSaveDataDto**](WorkOrderSaveDataDto.md) |             |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicesetcurrentprojectionsteps"></a>

# **WorkOrderServiceSetCurrentProjectionSteps**

> ResultDto WorkOrderServiceSetCurrentProjectionSteps (SetProjectionStepsDto setIndices)

Selects a range of process steps by NAME from the Work order's list and projects them.

Specifies the start and end steps - by NAME - in a range from the Work Order's Process Step List. The steps selected are
highlighted in Iris Client and begin projection. IF the names provided are not unique in the Work Order, the first steps
with those names are used. See also `/SetCurrentProjectionStepsWithId` which can be used to change Step List selection
by `EntityUniqueID`. * **StepNames** - the steps, by name, that bound the step list selection; if only one is specified
THAT step becomes selected; if none are provided the entire Process Step List is deselected.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceSetCurrentProjectionStepsExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var setIndices = new SetProjectionStepsDto(); // SetProjectionStepsDto | Work order name, client id and step indices

            try
            {
                // Selects a range of process steps by NAME from the Work order's list and projects them.
                ResultDto result = apiInstance.WorkOrderServiceSetCurrentProjectionSteps(setIndices);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceSetCurrentProjectionSteps: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                                  | Description                                 | Notes 
----------------|-------------------------------------------------------|---------------------------------------------|-------
 **setIndices** | [**SetProjectionStepsDto**](SetProjectionStepsDto.md) | Work order name, client id and step indices |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="workorderservicesetcurrentprojectionstepswithid"></a>

# **WorkOrderServiceSetCurrentProjectionStepsWithId**

> ResultDto WorkOrderServiceSetCurrentProjectionStepsWithId (SetProjectionStepsWithIdDto setIndices)

Selects a range of process steps by ID from the Work order's list and projects them.

Specifies the start and end steps - by ID - in a range from the Work Order's Process Step List. The steps selected are
highlighted in Iris Client and begin projection. Use `/GetCurrentProjectionEntities` or `/GetWorkOrderEntityAccessInfo`
to obtain unique EntityUniqueID for Process Step List elements. * **StepIDs** - the unique step identifiers (
`EntityUniqueID`), that bound the step list selection; if only one is specified THAT step becomes selected; if none are
provided the entire Process Step List is deselected.

### Example

```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceSetCurrentProjectionStepsWithIdExample
    {
        public void main()
        {
            var apiInstance = new ProjectionOperationsApi();
            var setIndices = new SetProjectionStepsWithIdDto(); // SetProjectionStepsWithIdDto | Work order name, client id and step indices

            try
            {
                // Selects a range of process steps by ID from the Work order's list and projects them.
                ResultDto result = apiInstance.WorkOrderServiceSetCurrentProjectionStepsWithId(setIndices);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionOperationsApi.WorkOrderServiceSetCurrentProjectionStepsWithId: " + e.Message );
            }
        }
    }
}
```

### Parameters

 Name           | Type                                                              | Description                                 | Notes 
----------------|-------------------------------------------------------------------|---------------------------------------------|-------
 **setIndices** | [**SetProjectionStepsWithIdDto**](SetProjectionStepsWithIdDto.md) | Work order name, client id and step indices |

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

- **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
- **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

