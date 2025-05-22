# VisionAndProjectionService.Swagger.Api.ProjectionApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CoreLaserServiceAddProjectPolygon**](ProjectionApi.md#corelaserserviceaddprojectpolygon) | **POST** /AddProjectPolygon | Adds raw PLY data directly to the Work Order&#39;s Display List and Process Step List.
[**CoreLaserServiceClearAllProjectedEntities**](ProjectionApi.md#corelaserserviceclearallprojectedentities) | **POST** /ClearAllProjectedEntities | Clears all projections (process steps, plies, ad-hoc projections) from the laser projected Display List.
[**CoreLaserServiceClearAndPauseProjection**](ProjectionApi.md#corelaserserviceclearandpauseprojection) | **POST** /ClearAndPauseProjection | Pauses projection in the client session but also clears any selected ply or ad-hoc projection.
[**CoreLaserServiceGetProjectOperationsStates**](ProjectionApi.md#corelaserservicegetprojectoperationsstates) | **POST** /GetProjectOperationsStates | Returns on/off status of Targets, Target Labels and Projection Areas for this projector.
[**CoreLaserServicePauseAllProjection**](ProjectionApi.md#corelaserservicepauseallprojection) | **POST** /PauseAllProjection | Halts projection AND drift checking AND projected menus for the session.
[**CoreLaserServicePauseDriftCheck**](ProjectionApi.md#corelaserservicepausedriftcheck) | **POST** /PauseDriftCheck | Suspends drift checking for the Work Order.
[**CoreLaserServicePauseProjection**](ProjectionApi.md#corelaserservicepauseprojection) | **POST** /PauseProjection | Pauses projection of user/WO plies in the client session.
[**CoreLaserServicePauseProjectionForProjector**](ProjectionApi.md#corelaserservicepauseprojectionforprojector) | **POST** /PauseProjectionForProjector | Pauses projection for the projector specified by serial #.
[**CoreLaserServiceProjectEntities**](ProjectionApi.md#corelaserserviceprojectentities) | **POST** /ProjectEntities | Adds new process steps, modifies existing process steps, selects and projects them.
[**CoreLaserServiceProjectEntityByID**](ProjectionApi.md#corelaserserviceprojectentitybyid) | **POST** /ProjectEntityByID | Selects and projects an existing process step by ID (even from another Work Order).
[**CoreLaserServiceProjectEntityByName**](ProjectionApi.md#corelaserserviceprojectentitybyname) | **POST** /ProjectEntityByName | Selects and projects an existing process step by name (even from another Work Order).
[**CoreLaserServiceRemoveEntities**](ProjectionApi.md#corelaserserviceremoveentities) | **POST** /RemoveEntities | Removes the named process step(s) from active projection in the the Work Order&#39;s Display List and the Process Step List if applicable.
[**CoreLaserServiceRemoveEntitiesWithId**](ProjectionApi.md#corelaserserviceremoveentitieswithid) | **POST** /RemoveEntitiesWithId | Removes the process step(s) specified by ID from active projection in the the Work Order&#39;s Display List and the Process Step List if applicable.
[**CoreLaserServiceRemoveProjectPolygons**](ProjectionApi.md#corelaserserviceremoveprojectpolygons) | **POST** /RemoveProjectPolygons | Removes raw PLY data by NAME from the Work Order.
[**CoreLaserServiceRemoveProjectPolygonsWithId**](ProjectionApi.md#corelaserserviceremoveprojectpolygonswithid) | **POST** /RemoveProjectPolygonsWithId | Removes the raw PLY data by unique ID from the Work Order.
[**CoreLaserServiceResumeAllProjection**](ProjectionApi.md#corelaserserviceresumeallprojection) | **POST** /ResumeAllProjection | Resumes projection AND drift checking AND projected menus for the session.
[**CoreLaserServiceResumeDriftCheck**](ProjectionApi.md#corelaserserviceresumedriftcheck) | **POST** /ResumeDriftCheck | Resume drift checking for the session.
[**CoreLaserServiceResumeProjection**](ProjectionApi.md#corelaserserviceresumeprojection) | **POST** /ResumeProjection | Resume projection for this client session named by ClientId.
[**CoreLaserServiceResumeProjectionForProjector**](ProjectionApi.md#corelaserserviceresumeprojectionforprojector) | **POST** /ResumeProjectionForProjector | Resumes projection for the projector specified by serial #.
[**CoreLaserServiceSetDistributorType**](ProjectionApi.md#corelaserservicesetdistributortype) | **POST** /SetDistributorType | Switch the Work Order between Clipping and Overlap modes.
[**CoreLaserServiceShowProjectionArea**](ProjectionApi.md#corelaserserviceshowprojectionarea) | **POST** /ShowProjectionArea | Toggles projection of a projector&#39;s area and center.


<a name="corelaserserviceaddprojectpolygon"></a>
# **CoreLaserServiceAddProjectPolygon**
> ResultDtoString CoreLaserServiceAddProjectPolygon (ProjectPolygonDto projectPolygon)

Adds raw PLY data directly to the Work Order's Display List and Process Step List.

Accepts projection data in raw coordinates (same as Work Order PLY files). When projecting, Iris will sweep from the first point to the last (if you want a closed polygon, repeat the first coordinate as the last)  See \"Ad-Hoc Projection Entities\" in the Integrators Guide for why/when you'd want to use this vs. `/ProjectEntities`  Any projections added here (with a name provided) show in the Iris Process Step List (if Iris is open), are visualized in the 3D/CAD view and are automatically projected by the appropriate lasers.  Projections added via API show as dark green in the 3D/CAD view, and the selection  highlight in the Process Step List is dark green as well (steps that existed in the Work Order when opened are highlighted in light green).    Steps added via `/AddProjectPolygon` immediately replace any contents of the Work Order's Display List. Note that if you do not provide a Name, the new step is NOT added to the Work Order's Process Step List.  Selection of steps in the Work Order's Process Step List is unaffected by this method; Next/Previous commands will still be operating on whichever steps were previously selected (in an open Iris Client, or using `/SetCurrentSelectionSteps`.)    * **Name** - If provided, is the ply name as shown in Iris' Process Step List; does not have to be unique; methods that require named process steps (like `/RemoveProjectPolygons` and `/RemoveEntities`) may not behave as expected if the specified process step exists more than once; in most cases, the first occurrence of that step name will be addressed only. Where duplicate step or layer names are expected, `EntityUniqueID` specific endpoints (e.g. `/RemoveEntitiesWithID`, `/RemoveProjectPolygonsWithId`) can be used, after retrieving step and layer `EntityUniqueID` values using `/GetCurrentProjectionEntities` or `/GetWorkOrderEntityAccessInfo`.  * **ID** - Corresponds to EntityUniqueID; the identifier that uniquely identifies steps - MUST be unique in the Work Order. If not provided, is created and assigned automatically. This is the parameter used by `/RemoveProjectPolygonsWithId`.  * **Units** - Units the projection points in 'NormalPointsData' are specified in; does not have to match that of the open Work Order, Iris will convert; see \"Units\" in Integrators Guide  * **Type** - use \"Polygon\"; other values are unsupported at this time.  * **NormalPointsData** - string containing raw projection coordinates (.ply file format), one line per projection point with 2,3 or 6 values space separated: 2 values = 2D point (z=0)  3 values = 3D point (x,y,z); 6 values = 3D point (x,y,z) with normal vector (a,b,c - do not have to be normalized)    <example>               0.684006 9.976661 0.100000 0.000000 0.000000 1               1.242432 9.976661 0.100000 0.000000 0.000000 1               1.242432 6.380219 0.100000 0.000000 0.000000 1               3.505415 6.380219 0.100000 0.000000 0.000000 1               3.505415 9.976661 0.100000 0.000000 0.000000 1               4.387138 9.976661 0.100000 0.000000 0.000000 1               4.387138 8.162716 0.100000 0.000000 0.000000 1               6.938428 8.162716 0.100000 0.000000 0.000000 1               6.938428 11.082913 0.100000 0.000000 0.000000 1               5.713986 11.082913 0.100000 0.000000 0.000000 1               5.713986 11.582541 0.100000 0.000000 0.000000 1               7.913908 11.582541 0.100000 0.000000 0.000000 1               7.913908 15.575661 0.100000 0.000000 0.000000 1               3.505415 15.575661 0.100000 0.000000 0.000000 1               3.505415 13.949827 0.100000 0.000000 0.000000 1               0.684006 13.949827 0.100000 0.000000 0.000000 1               0.684006 9.976661 0.100000 0.000000 0.000000 1               </example>    **Note** - step and layer \"uniqueness\" and the behaviour of this method depends on BOTH the step/layer NAME (argument `Name`) and its unique Identifier EntityUniqueId (argument `Id`).   If you specify:   EXISTING/NO Name + EXISTING Id - this is IGNORED; to \"switch\" to an existing step with either Name or Id, use `/AddEntity`.  EXISTING Name + NEW Id - creates new (duplicate) step named Name; discards the provided Id and auto-generates new one  EXISTING Name + NO Id - creates new (duplicate) step named Name; auto-generates the Id  NEW Name + EXISTING Id - creates new (new) step named Name; IGNORES the provided Id and auto-generates new one  NEW Name + NEW Id - creates new (new) step named Name; IGNORES the provided Id and auto-generates new one  NEW Name + NO Id - creates a new step named Name, auto-generates Id  See \"Process Step Uniqueness\" in the Integrator's Guide for more details. Also note that any Id (EntityUniqueId) automatically generated will be decreasing integrators (-1, -2, -3)...

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceAddProjectPolygonExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var projectPolygon = new ProjectPolygonDto(); // ProjectPolygonDto | 

            try
            {
                // Adds raw PLY data directly to the Work Order's Display List and Process Step List.
                ResultDtoString result = apiInstance.CoreLaserServiceAddProjectPolygon(projectPolygon);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceAddProjectPolygon: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectPolygon** | [**ProjectPolygonDto**](ProjectPolygonDto.md)|  | 

### Return type

[**ResultDtoString**](ResultDtoString.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceclearallprojectedentities"></a>
# **CoreLaserServiceClearAllProjectedEntities**
> ResultDto CoreLaserServiceClearAllProjectedEntities (ClientInfoDto clientInfo)

Clears all projections (process steps, plies, ad-hoc projections) from the laser projected Display List.

Removes all process step geometry/polygons from active laser projection regardless of whether they are steps/projections defined in the Work Order or added as ad-hoc projections using `/ProjectEntities` or `/AddProjectPolygon`.   Unlike `/ClearAndPauseProjection`, projection isn't actually paused (so Projected Menus will remain visible/projected by the lasers), there simply isn't anything TO project anymore.  The actual steps/Entities in the Work Order's Process Step List remain unchanged, as does the selection of steps.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceClearAllProjectedEntitiesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client information

            try
            {
                // Clears all projections (process steps, plies, ad-hoc projections) from the laser projected Display List.
                ResultDto result = apiInstance.CoreLaserServiceClearAllProjectedEntities(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceClearAllProjectedEntities: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceclearandpauseprojection"></a>
# **CoreLaserServiceClearAndPauseProjection**
> ResultDtoBoolean CoreLaserServiceClearAndPauseProjection (ClientInfoDto clientInfo)

Pauses projection in the client session but also clears any selected ply or ad-hoc projection.

Same as `/PauseProjection`, however any Operator (or API) selected plies, process steps, or ad-hoc projection (see `/ProjectEntities` and `/AddProjectPolygon`) have their selection CLEARED from the Process Step List so that `/ResumeProjection` will not show anything other than Projected Menus.  To show any Work Order or ad-hoc plies when projection is resumed with `/ResumeProjection`, Process Step List selections must be made by the Operator in Iris Client or via the API's `/SetCurrentSelectionSteps`.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceClearAndPauseProjectionExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client Projector information

            try
            {
                // Pauses projection in the client session but also clears any selected ply or ad-hoc projection.
                ResultDtoBoolean result = apiInstance.CoreLaserServiceClearAndPauseProjection(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceClearAndPauseProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client Projector information | 

### Return type

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectoperationsstates"></a>
# **CoreLaserServiceGetProjectOperationsStates**
> ResultDtoValueTupleBooleanBooleanBoolean CoreLaserServiceGetProjectOperationsStates (ClientProjectorInfoDto clientProjectorInfo)

Returns on/off status of Targets, Target Labels and Projection Areas for this projector.

Returns boolean values representing the on/off status of:  * **Project All Targets** - see `ProjectTargets` in `/TargetProjection`  * **Show Labels** - see `ShowLabels` in `/TargetProjection`  * **Project Area** - see `/ShowProjectionArea`

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectOperationsStatesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns on/off status of Targets, Target Labels and Projection Areas for this projector.
                ResultDtoValueTupleBooleanBooleanBoolean result = apiInstance.CoreLaserServiceGetProjectOperationsStates(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceGetProjectOperationsStates: " + e.Message );
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

[**ResultDtoValueTupleBooleanBooleanBoolean**](ResultDtoValueTupleBooleanBooleanBoolean.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicepauseallprojection"></a>
# **CoreLaserServicePauseAllProjection**
> ResultDto CoreLaserServicePauseAllProjection (ClientInfoDto clientInfo)

Halts projection AND drift checking AND projected menus for the session.

Same as `/PauseDriftCheck` and `/PauseProjection` but includes Projected Menus, for the session. Multiple calls will stack.    **Note** drift checks are automatically re-enabled by successful completion of Manual Calibration and any operation which modifies Projected Menus.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServicePauseAllProjectionExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | 

            try
            {
                // Halts projection AND drift checking AND projected menus for the session.
                ResultDto result = apiInstance.CoreLaserServicePauseAllProjection(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServicePauseAllProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicepausedriftcheck"></a>
# **CoreLaserServicePauseDriftCheck**
> ResultDto CoreLaserServicePauseDriftCheck (ClientInfoDto clientInfo)

Suspends drift checking for the Work Order.

Periodic drift checks will be suspended for the Work Order; resume with `/ResumeDriftCheck`.    **Note** drift checks are automatically re-enabled by successful completion of Manual Calibration and any operation which modifies Projected Menus.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServicePauseDriftCheckExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client information

            try
            {
                // Suspends drift checking for the Work Order.
                ResultDto result = apiInstance.CoreLaserServicePauseDriftCheck(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServicePauseDriftCheck: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicepauseprojection"></a>
# **CoreLaserServicePauseProjection**
> ResultDto CoreLaserServicePauseProjection (ClientInfoDto clientInfo)

Pauses projection of user/WO plies in the client session.

Removes any Operator (or API) selected plies, process steps, or ad-hoc projections (see `/ProjectEntities` and `/AddProjectPolygon`) from the Display List of all projectors, EXCEPT for Projected Menus.  Process Step List contents of the WO are unaffected; Process Step List selection is unaffected; selected steps remain highlighted in Iris Clients and will resume on `/ResumeProjection`.  Drift checking for paused projectors is suspended, but will also resume with `/ResumeProjection`. Multiple calls do not stack.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServicePauseProjectionExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client information

            try
            {
                // Pauses projection of user/WO plies in the client session.
                ResultDto result = apiInstance.CoreLaserServicePauseProjection(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServicePauseProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicepauseprojectionforprojector"></a>
# **CoreLaserServicePauseProjectionForProjector**
> ResultDto CoreLaserServicePauseProjectionForProjector (ClientProjectorInfoDto clientProjectorInfo)

Pauses projection for the projector specified by serial #.

Same as `/PauseProjection` but only for the specified projector; pauses Drift Checking - for this projector - as well. Multiple calls will stack.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServicePauseProjectionForProjectorExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | client information

            try
            {
                // Pauses projection for the projector specified by serial #.
                ResultDto result = apiInstance.CoreLaserServicePauseProjectionForProjector(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServicePauseProjectionForProjector: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceprojectentities"></a>
# **CoreLaserServiceProjectEntities**
> ResultDto CoreLaserServiceProjectEntities (ProjectEntitiesDto entities)

Adds new process steps, modifies existing process steps, selects and projects them.

Adds ad-hoc or temporary process steps to the open Work Order or modifies(1) existing process steps.   Existing process steps are specified by the provided `EntityUniqueId` or by `EntityName`; if `EntityName` is not unique, the first with that name will be modified. If `EntityUniqueId` or `EntityName` do not match an existing step in the open Work Order, a new step with those parameters is created. `PlyBlocks`, if provided, will create projection/polygon actions, `TextBlocks`, if provided, will create projected text step actions. (See \"Iris Authoring\" in the Operator Guide.)    If neither (valid) `PlyBlock` or `TextBlock` is provided, no steps will be created (i.e. no empty steps are generated.) or modified; if the specified `EntityUniqueId` or `EntityName` reference an existing process step, it is not switched to (selected and displayed in the Display List). To simply change Work Order selection/projection to an existing process step see `/ProjectEntityById` and `/ProjectEntityByName`    **IgnoreNormals** - if true, the system will attempt to project all polygons or text in this new or modified step regardless of surface normals    **AppendProjection** - if true, the step entities added via this method are added to the Work Order's active Display List and Process Step selection; if false, all existing laser projections and step selections are replaced by these new or modified entities.     **PlyUnits** (required) - units for specified polygon or text coordinates;     **PlyBlock** - a collection of `Points`, each with a coordinate and surface normal at that coordinate. Remember, in order to project a closed polygon the last coordinate must equal the first.  The `IsCrosshair` attribute will include this polygon in the collection that can be toggled off and on with the Options &gt; Crosshairs feature.     **TextBlock** - Projected Text - both the text to display itself, and 3 points to define the origin, orientation, and projection plane of the Projected Text chevron (the angle icon used to locate and toggle Projected Text. The 3 coordinates of the chevron, in order, are bottom-left, vertex, and upper-left. The plane defined by the coordinates of the text chevron becomes the projection plane for the text. The size of the chevron is used for text size. Only a subset of ASCII characters are supported by the Projected Text laser font: `a-z A-Z 0-9 \\_ . , ? \\! ; : \\- \\+ \\* / \\\\ \\| \\( \\) { } [ ] \\# @ \\~ `. For more information on defining projected text see \"Iris Authoring\" in the Operator Guide.    **ActionType** - (optional) the step actions to be tracked for these entities. This section can be removed for 'ProjectOnly' operations, or use 'Polygon'.  Legal actions are from the supported ply actions in the Iris Authoring Guide.    **AdditionalProperties** - (optional) a dictionary capable of holding any properties that don't fit into a set category.   For example, the duration of a countdown timer.   This section can be removed for 'ProjectOnly' operations    * **Operation** - Typically use 'ProjectSkipInspectingCurrent' for updating the projection.  Other options are 'UpdateDisplayOnly' for client UI updates, 'ProjectAfterInspectingCurrent' for updating multiple services when adding a camera action, 'ProjectOnly' for projector projection update only (currently only pick n project is using this flag), and 'ProjectAfterLoggingInfo'.    * **ActionOverrideInfo** - (optional) the user override information for failed inspection actions.  This section can be removed for 'ProjectOnly' operations.    * **ActionTrackInfo** - (optional) the display step actions to be tracked before project the new entities.  This section can be removed for 'ProjectOnly' operations.    * **EntityUniqueId** - the unique ID of the step; if creating a new ad hoc step this must be distinct from any ids already in use by the system; ids can be retrieved using `/GetCurrentProjectionEntities` or `/GetProjectionData` if needed.    * **EntityName** - the name of the step; if the step name specified is NOT unique, the first step that matches the name is used; must match the EntityUniqueId if modifying an existing step.  See \"Ad-hoc Projections\" in the Integrators Reference.    (1) *No changes to the Process Step List, projection (`.ply`) file made by this endpoint will be saved, even if the Work Order is saved in Iris Client.*

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceProjectEntitiesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var entities = new ProjectEntitiesDto(); // ProjectEntitiesDto | 

            try
            {
                // Adds new process steps, modifies existing process steps, selects and projects them.
                ResultDto result = apiInstance.CoreLaserServiceProjectEntities(entities);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceProjectEntities: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entities** | [**ProjectEntitiesDto**](ProjectEntitiesDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceprojectentitybyid"></a>
# **CoreLaserServiceProjectEntityByID**
> ResultDto CoreLaserServiceProjectEntityByID (ProjectEntityWithFullNameDto fullNameDto)

Selects and projects an existing process step by ID (even from another Work Order).

Projects the process step identified by its unique id. If the specified `EntityUniqueId` does not exist in the open Work Order an error is returned and there is no change to active Work Order selection or projection.     * **EntityUniqueId** - the unique ID of the step; can be retrieved using `/GetCurrentProjectionEntities` or `/GetProjectionData` if needed     * **WorkOrderName** - Required.    * **ConfigurationProfileName** (optional) used to parse the projection data if an external Work Order is specified.     * **IgnoreNormals** - if true, the system will attempt to project these steps regardless of surface normals    * **AppendProjection** - if true, the step entities specified are added to the Work Order's active Display List and Process Step selection; if false, all existing laser projections and step selections are replaced by these step entities.     * **EntityFullName** - anything specified here is ignored  * **Operation** - the type of operation, possible choices include: ProjectOnly, ProjectAfterInspectingCurrent, ProjectSkipInspectingCurrent    * **ActionOverrideInfo** - the user override information for failed inspection actions    * **ActionTrackInfo** - the display step actions to be tracked before project the new entities      *No changes to the Process Step List, projection (`.ply`) file made by this endpoint will be saved, even if the Work Order is saved in Iris Client.*

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceProjectEntityByIDExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var fullNameDto = new ProjectEntityWithFullNameDto(); // ProjectEntityWithFullNameDto | 

            try
            {
                // Selects and projects an existing process step by ID (even from another Work Order).
                ResultDto result = apiInstance.CoreLaserServiceProjectEntityByID(fullNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceProjectEntityByID: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fullNameDto** | [**ProjectEntityWithFullNameDto**](ProjectEntityWithFullNameDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceprojectentitybyname"></a>
# **CoreLaserServiceProjectEntityByName**
> ResultDto CoreLaserServiceProjectEntityByName (ProjectEntityWithFullNameDto fullNameDto)

Selects and projects an existing process step by name (even from another Work Order).

Project the process step identified by its name. If the specified step name does not exist in the open Work Order, an error is returned and there is no change to the active Work Order selection or projection. If the name as specified does not resolve to a single unique process step, the first by that name is used.    Unique step and layer names are provided by listing parent layers e.g. `/layer/sub-layer/stepname` as it is returned by `/GetCurrentProjectionEntities`.    * **EntityFullName** - the name of the step. If the step name specified is NOT unique, the first step that matches the name is used; if duplicate step or layer names are a possibility, use the methods `/GetCurrentProjectionEntities` or `/GetProjectionData` to determine `EntityUniqueId` and use `/ProjectEntityByID` instead.     * **WorkOrderName** - Required.    * **ConfigurationProfileName** (optional) used to parse the projection data if an external Work Order is specified.    * **IgnoreNormals** - if true, the system will attempt to project these steps regardless of surface normals    * **AppendProjection** - if true, the step entities specified are added to the Work Order's active Display List and Process Step selection; if false, all existing laser projections and step selections are replaced by these step entities.     * **EntityUniqueId** - anything specified here is ignored    *No changes to the Process Step List, projection (.ply) file made by this endpoint will be saved, even if the Work Order is saved in Iris Client.*

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceProjectEntityByNameExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var fullNameDto = new ProjectEntityWithFullNameDto(); // ProjectEntityWithFullNameDto | 

            try
            {
                // Selects and projects an existing process step by name (even from another Work Order).
                ResultDto result = apiInstance.CoreLaserServiceProjectEntityByName(fullNameDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceProjectEntityByName: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **fullNameDto** | [**ProjectEntityWithFullNameDto**](ProjectEntityWithFullNameDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceremoveentities"></a>
# **CoreLaserServiceRemoveEntities**
> ResultDto CoreLaserServiceRemoveEntities (RemoveEntitiesDto entities)

Removes the named process step(s) from active projection in the the Work Order's Display List and the Process Step List if applicable.

Removes the ply or process step list entities by NAME that have been added by `/ProjectEntities`.   Specified removed entities are removed from the Display List and their visualization is removed from the 3D/CAD View.  If the removed step/entity is part of the current Process Step List selection,   the previous step is added to the selection automatically (if applicable); no need to call `/SetCurrentSelectionSteps`.  If the named process step was NOT added by `/ProjectEntities`, then it is NOT removed from the Work Order's Process Step List.   Cannot remove layers; although if this method removes all entities within a layer, the layer is removed as well.     **EntityNames** - Names of the steps to remove.   If the step name specified is NOT unique, the first step with that name is removed;   if duplicate step or layer names are a possibility, use the methods   `/GetCurrentProjectionEntities` or `/GetWorkOrderEntityAccessInfo` to determine   the specific `EntityUniqueID`, then use `/RemoveEntitiesWithId`    *Note** this method can only remove entities added using `/AddEntity`. To remove ad-hoc projection coordinates added using `/AddProjectPolygon`, use `/RemoveProjectPolygons` or `/RemoveProjectPolygonsWithId`. Named steps that were in the Work Order when it was opened are NOT removed via this method (in essence, Work Order contents cannot be modified by API calls)    * **RemoveCrosshairs** - if true, will remove ONLY the Entities with the `IsCrosshair` attribute also set to true; in effect, this can be used to trigger the same effect as toggling Crosshairs off in Iris (Options menu).  * **EntityIds** - this field is **obsolete** because it was poorly named.   It has always required the name of the polygon to remove, not the id.   While it can be used if provided with the name for backwards compatibility, any new implementation should be using **EntityNames** instead.  If you want to use **EntityNames**, then you should completely remove **EntityIds** by deleting the following code:   <example>               \"EntityIds\": [                 \"string\"               ]               </example>  Do **not** use both fields as EntityIDs will replace EntityNames if they are both provided.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceRemoveEntitiesExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var entities = new RemoveEntitiesDto(); // RemoveEntitiesDto | 

            try
            {
                // Removes the named process step(s) from active projection in the the Work Order's Display List and the Process Step List if applicable.
                ResultDto result = apiInstance.CoreLaserServiceRemoveEntities(entities);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceRemoveEntities: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entities** | [**RemoveEntitiesDto**](RemoveEntitiesDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceremoveentitieswithid"></a>
# **CoreLaserServiceRemoveEntitiesWithId**
> ResultDto CoreLaserServiceRemoveEntitiesWithId (RemoveEntitiesWithIdDto entities)

Removes the process step(s) specified by ID from active projection in the the Work Order's Display List and the Process Step List if applicable.

Removes the ply or process step list entities by ID that have been added by `/ProjectEntities`.   Specified removed entities are removed from the Display List and their visualization is removed from the 3D/CAD View.  If the removed step/entity is part of the current Process Step List selection,   the previous step is added to the selection automatically (if applicable); no need to call `/SetCurrentSelectionSteps`.  If the named process step was NOT added by `/ProjectEntities`, then it is NOT removed from the Work Order's Process Step List.   Cannot remove layers; although if this method removes all entities within a layer, the layer is removed as well.     **EntityIds** - the integer `EntityUniqueIds` of the steps to remove. Use the methods `/GetCurrentProjectionEntities` or `/GetWorkOrderEntityAccessInfo` to determine   the specific `EntityUniqueID`    *Note** this method can only remove entities added using `/AddEntity`. To remove ad-hoc projection coordinates added using `/AddProjectPolygon`, use `/RemoveProjectPolygons` or `/RemoveProjectPolygonsWithId`. Named steps that were in the Work Order when it was opened are NOT removed via this method (in essence, Work Order contents cannot be modified by API calls)    * **RemoveCrosshairs** - if true, will remove ONLY the Entities with the `IsCrosshair` attribute also set to true; in effect, this can be used to trigger the same effect as toggling Crosshairs off in Iris (Options menu).

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceRemoveEntitiesWithIdExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var entities = new RemoveEntitiesWithIdDto(); // RemoveEntitiesWithIdDto | 

            try
            {
                // Removes the process step(s) specified by ID from active projection in the the Work Order's Display List and the Process Step List if applicable.
                ResultDto result = apiInstance.CoreLaserServiceRemoveEntitiesWithId(entities);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceRemoveEntitiesWithId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entities** | [**RemoveEntitiesWithIdDto**](RemoveEntitiesWithIdDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceremoveprojectpolygons"></a>
# **CoreLaserServiceRemoveProjectPolygons**
> ResultDto CoreLaserServiceRemoveProjectPolygons (RemoveEntitiesDto entities)

Removes raw PLY data by NAME from the Work Order.

Removes the specified entities by NAME that have been added by `/AddProjectPolygon`.  Specified removed polygons are removed from the Display List and their visualization is removed from the 3D/CAD View. If the removed step/entity is part of the current Process Step List selection,   the previous step is added to the selection automatically (if applicable); no need to call `/SetCurrentSelectionSteps`.  IF the specified step name is not unique, then the first step with that name is removed. See also `/RemoveProjectPolygonsWithId`    **Note** this method can only remove entities added using `/AddProjectPolygon`. To remove ad-hoc projection entities added using `/ProjectEntities`, use `/RemoveEntities`.    * **RemoveCrosshairs** - if true, will remove ONLY the Polygons with the `IsCrosshair` attribute also set to true; in effect, this can be used to trigger the same effect as toggling Crosshairs off in Iris (Options menu).  * **EntityIds** - this field is **obsolete** because it was poorly named.   It has always required the name of the polygon to remove, not the id.   While it can be used if provided with the name for backwards compatibility, any new implementation should be using **EntityNames** instead.  If you want to use **EntityNames**, then you should completely remove **EntityIds** by deleting the following code:  <example>               \"EntityIds\": [                 \"string\"               ]               </example>  Do **not** use both fields as EntityIDs will replace EntityNames if they are both provided.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceRemoveProjectPolygonsExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var entities = new RemoveEntitiesDto(); // RemoveEntitiesDto | 

            try
            {
                // Removes raw PLY data by NAME from the Work Order.
                ResultDto result = apiInstance.CoreLaserServiceRemoveProjectPolygons(entities);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceRemoveProjectPolygons: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entities** | [**RemoveEntitiesDto**](RemoveEntitiesDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceremoveprojectpolygonswithid"></a>
# **CoreLaserServiceRemoveProjectPolygonsWithId**
> ResultDto CoreLaserServiceRemoveProjectPolygonsWithId (RemoveEntitiesWithIdDto entities)

Removes the raw PLY data by unique ID from the Work Order.

Removes the specified entities by ID that have been added by `/AddProjectPolygon`.  Specified removed polygons are removed from the Display List and their visualization is removed from the 3D/CAD View. If the removed step/entity is part of the current Process Step List selection,   the previous step is added to the selection automatically (if applicable); no need to call `/SetCurrentSelectionSteps`.    The methods `/GetCurrentProjectionEntities` and `/GetWorkOrderEntityAccessInfo` can be used to to obtain the `EntityUniqueID` for the desired steps.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceRemoveProjectPolygonsWithIdExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var entities = new RemoveEntitiesWithIdDto(); // RemoveEntitiesWithIdDto | 

            try
            {
                // Removes the raw PLY data by unique ID from the Work Order.
                ResultDto result = apiInstance.CoreLaserServiceRemoveProjectPolygonsWithId(entities);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceRemoveProjectPolygonsWithId: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **entities** | [**RemoveEntitiesWithIdDto**](RemoveEntitiesWithIdDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceresumeallprojection"></a>
# **CoreLaserServiceResumeAllProjection**
> ResultDto CoreLaserServiceResumeAllProjection (ClientInfoDto clientInfo)

Resumes projection AND drift checking AND projected menus for the session.

Same as `/ResumeDriftCheck` and `/ResumeProjection` but includes Projected Menus, for the session. Needed to be called as many times as `/PauseAllProjection`.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceResumeAllProjectionExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | 

            try
            {
                // Resumes projection AND drift checking AND projected menus for the session.
                ResultDto result = apiInstance.CoreLaserServiceResumeAllProjection(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceResumeAllProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceresumedriftcheck"></a>
# **CoreLaserServiceResumeDriftCheck**
> ResultDto CoreLaserServiceResumeDriftCheck (ClientInfoDto clientInfo)

Resume drift checking for the session.

Resumes periodic drift checks for the session Work Order.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceResumeDriftCheckExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client information

            try
            {
                // Resume drift checking for the session.
                ResultDto result = apiInstance.CoreLaserServiceResumeDriftCheck(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceResumeDriftCheck: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceresumeprojection"></a>
# **CoreLaserServiceResumeProjection**
> ResultDto CoreLaserServiceResumeProjection (ClientInfoDto clientInfo)

Resume projection for this client session named by ClientId.

Resumes projection of all currently selected Process Steps in the Work Order associated with this client session. Identical  behavior as resuming projection in Iris Client. Calls to resume an already  projecting Work Order is ignored. Also resumes Drift Checking. Only needs to be called once

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceResumeProjectionExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientInfo = new ClientInfoDto(); // ClientInfoDto | client information

            try
            {
                // Resume projection for this client session named by ClientId.
                ResultDto result = apiInstance.CoreLaserServiceResumeProjection(clientInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceResumeProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientInfo** | [**ClientInfoDto**](ClientInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceresumeprojectionforprojector"></a>
# **CoreLaserServiceResumeProjectionForProjector**
> ResultDto CoreLaserServiceResumeProjectionForProjector (ClientProjectorInfoDto clientProjectorInfo)

Resumes projection for the projector specified by serial #.

Same as `/ResumeProjection` but only for the specified projector; resumes Drift Checking - for this projector - as well. Needed to be called as many times as `/PauseProjectionForProjector`.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceResumeProjectionForProjectorExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | client information

            try
            {
                // Resumes projection for the projector specified by serial #.
                ResultDto result = apiInstance.CoreLaserServiceResumeProjectionForProjector(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceResumeProjectionForProjector: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| client information | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicesetdistributortype"></a>
# **CoreLaserServiceSetDistributorType**
> ResultDto CoreLaserServiceSetDistributorType (DistributorTypeDto type)

Switch the Work Order between Clipping and Overlap modes.

Changes the Work Order to behave in Clipping or Overlapping modes (same as Iris  Client &gt; Options). Has no bearing on Manual Clipping Zones (see Iris Administrator  Guide) - if they are defined in the Work Order they are used, if not the system  automatically defines clipping boundaries between projectors to share projection  workload evenly.    **DisplayDistributorType**:    * Normal - Clipping mode  * OverlappedTextIgnoringNormals - Overlapping mode  * OverlappedTextUsingNormals - not currently used

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceSetDistributorTypeExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var type = new DistributorTypeDto(); // DistributorTypeDto | the given type needs to be set in the client

            try
            {
                // Switch the Work Order between Clipping and Overlap modes.
                ResultDto result = apiInstance.CoreLaserServiceSetDistributorType(type);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceSetDistributorType: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **type** | [**DistributorTypeDto**](DistributorTypeDto.md)| the given type needs to be set in the client | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceshowprojectionarea"></a>
# **CoreLaserServiceShowProjectionArea**
> ResultDtoBoolean CoreLaserServiceShowProjectionArea (ClientProjectorInfoDto clientProjectorInfo)

Toggles projection of a projector's area and center.

Toggles the display of the specified projector's projection area boundary (box) and center of view (crosshairs), as though the \"Project Area and Center of Area\" button had been toggled in the corresponding Projector Panel &gt; Targets Tab in Iris Client. Shows the field of view center and maximum projection extents for the projector; useful in ensuring projection coverage.  <example>              ClientProjectorInfoDto {                ClientId (string, required),                ProjectorSerial (string, required)              }              </example>

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceShowProjectionAreaExample
    {
        public void main()
        {
            var apiInstance = new ProjectionApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Toggles projection of a projector's area and center.
                ResultDtoBoolean result = apiInstance.CoreLaserServiceShowProjectionArea(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling ProjectionApi.CoreLaserServiceShowProjectionArea: " + e.Message );
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

[**ResultDtoBoolean**](ResultDtoBoolean.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

