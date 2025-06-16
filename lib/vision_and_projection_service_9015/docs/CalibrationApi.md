# VisionAndProjectionService.Swagger.Api.CalibrationApi

All URIs are relative to *http://localhost:9015*

Method | HTTP request | Description
------------- | ------------- | -------------
[**CoreLaserServiceAutoCalibration**](CalibrationApi.md#corelaserserviceautocalibration) | **POST** /AutoCalibration | Triggers an Automatic Alignment (or FlashAlign) attempt with the specified projector.
[**CoreLaserServiceAutoCalibrationExtended**](CalibrationApi.md#corelaserserviceautocalibrationextended) | **POST** /AutoCalibrationExtended | Perform an Automatic Alignment the same as using AutoCalibration, but use the configured value of ProjectUsingSavedAlignment
[**CoreLaserServiceCancelAutoCalibration**](CalibrationApi.md#corelaserservicecancelautocalibration) | **POST** /CancelAutoCalibration | Cancels an Automatic Alignment attempt in progress with the specified projector.
[**CoreLaserServiceGetCalibrationDetail**](CalibrationApi.md#corelaserservicegetcalibrationdetail) | **POST** /GetCalibrationDetail | Returns detailed alignment information for the specified projector.
[**CoreLaserServiceGetCalibrationError**](CalibrationApi.md#corelaserservicegetcalibrationerror) | **POST** /GetCalibrationError | Retrieves the current alignment error of the specified projector to its observable alignment targets.
[**CoreLaserServiceGetModelPosition**](CalibrationApi.md#corelaserservicegetmodelposition) | **POST** /GetModelPosition | Returns model (tool) location and orientation in projector coordinates.
[**CoreLaserServiceGetProjectorAlignmentState**](CalibrationApi.md#corelaserservicegetprojectoralignmentstate) | **POST** /GetProjectorAlignmentState | Returns the Alignment Status of the specified projector.
[**CoreLaserServiceGetProjectorPosition**](CalibrationApi.md#corelaserservicegetprojectorposition) | **POST** /GetProjectorPosition | Returns projector location and orientation in Work Order tool coordinates.
[**CoreLaserServiceInitializeProjectionAndSetupTool**](CalibrationApi.md#corelaserserviceinitializeprojectionandsetuptool) | **POST** /InitializeProjectionAndSetupTool | NOT SUPPORTED IN THIS VERSION - use /OpenTool
[**CoreLaserServiceTargetProjection**](CalibrationApi.md#corelaserservicetargetprojection) | **POST** /TargetProjection | Sets on/off \&quot;Project All Targets\&quot; or \&quot;Show Labels\&quot; for the specified projector.


<a name="corelaserserviceautocalibration"></a>
# **CoreLaserServiceAutoCalibration**
> ResultDto CoreLaserServiceAutoCalibration (ClientProjectorInfoDto clientProjectorInfo)

Triggers an Automatic Alignment (or FlashAlign) attempt with the specified projector.

Launches an Automatic Alignment of this projector; if the projector is vision capable, attempts a FlashAlign; same action as \"Locate Targets Automatically\" in Iris Client &gt; Projector Dashboard &gt; Targets Tab &gt; Alignment Controls, or via Projected Menus; see \"Performing an Automatic Alignment\" in Iris Operator Guide.    The projector will use any previously remembered target scan locations to predict where the targets are; if that fails (either there are no saved target scan locations or the tool targets are outside of the predicted search locations), the system will abandon the Automatic / FlashAlignment.  <example>               ClientProjectorInfoDto {                 ClientId (string, required),                 ProjectorSerial (string, required)               }               </example>

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceAutoCalibrationExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | the client and projector information data

            try
            {
                // Triggers an Automatic Alignment (or FlashAlign) attempt with the specified projector.
                ResultDto result = apiInstance.CoreLaserServiceAutoCalibration(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceAutoCalibration: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| the client and projector information data | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceautocalibrationextended"></a>
# **CoreLaserServiceAutoCalibrationExtended**
> ResultDto CoreLaserServiceAutoCalibrationExtended (ClientProjectorInfoDto clientProjectorInfo)

Perform an Automatic Alignment the same as using AutoCalibration, but use the configured value of ProjectUsingSavedAlignment

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceAutoCalibrationExtendedExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | the client, projector to align

            try
            {
                // Perform an Automatic Alignment the same as using AutoCalibration, but use the configured value of ProjectUsingSavedAlignment
                ResultDto result = apiInstance.CoreLaserServiceAutoCalibrationExtended(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceAutoCalibrationExtended: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| the client, projector to align | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicecancelautocalibration"></a>
# **CoreLaserServiceCancelAutoCalibration**
> ResultDto CoreLaserServiceCancelAutoCalibration (ClientProjectorInfoDto clientProjectorInfo)

Cancels an Automatic Alignment attempt in progress with the specified projector.

Tells the system to abandon any Automatic (or Flash)Alignment process ongoing with the specified projector; can be used to halt alignment which is taking an unexpectedly long time or needs to be abandoned for any reason.  <example>               ClientProjectorInfoDto {                 ClientId (string, required),                 ProjectorSerial (string, required)               }               </example>

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceCancelAutoCalibrationExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | the client and projector information data

            try
            {
                // Cancels an Automatic Alignment attempt in progress with the specified projector.
                ResultDto result = apiInstance.CoreLaserServiceCancelAutoCalibration(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceCancelAutoCalibration: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| the client and projector information data | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetcalibrationdetail"></a>
# **CoreLaserServiceGetCalibrationDetail**
> ResultDtoCalibrationDetailDto CoreLaserServiceGetCalibrationDetail (ClientProjectorInfoDto clientProjectorInfo)

Returns detailed alignment information for the specified projector.

Provides additional information that may be used to diagnose and troubleshoot a projector's poor alignment error (GetCalibrationError):  <example>                  CalibrationDetailDto {                    SerialNumber (string, optional),                    MaximumError (number, optional),                  RMSError (number, optional),                   CalibrationTolerance (number, optional),                   FailReason (string, optional),                   TotalAlignmentTargets (integer, optional),                   LocatedReferenceTargetCount (integer, optional)                   }                                  </example>  * **MaximumError** - worst target alignment error (in Feet) - this is also the value returned in `/GetCalibrationError`  * **RMSError** - RMS error (Feet)of all targets currently scannable by the laser projector  * **CalibrationTolerance** - the ALIGNMENT tolerance (in Feet) in use by this projector for target scans; corresponds to Maximum Alignment Error specified in Virtek Server Manager under Server (global) or Iris Client: Alignment Options or in Iris Client &gt; Work Order Options.   * **FailReason** - if the projector has failed alignment, this error string may indicate why.   * **TotalAlignmentTargets** - total number of Work Order targets (of type Alignment, Drift, Required) available for use in this Work Order (but not necessarily what can be seen by this projector)  * **LocatedReferenceTargetCount** - number of targets from the Total above which this projector has scanned successfully (to within tolerances.)

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetCalibrationDetailExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | client projector info DTO

            try
            {
                // Returns detailed alignment information for the specified projector.
                ResultDtoCalibrationDetailDto result = apiInstance.CoreLaserServiceGetCalibrationDetail(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceGetCalibrationDetail: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| client projector info DTO | 

### Return type

[**ResultDtoCalibrationDetailDto**](ResultDtoCalibrationDetailDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetcalibrationerror"></a>
# **CoreLaserServiceGetCalibrationError**
> ResultDtoDouble CoreLaserServiceGetCalibrationError (ClientProjectorInfoDto clientProjectorInfo)

Retrieves the current alignment error of the specified projector to its observable alignment targets.

Shows the maximum/worst case alignment error (in Feet) of the specified projector to its observable alignment targets, based on laser scans of those targets; this is the same number that is shown at the top of Iris Client &gt; Projector Dashboard &gt; Targets Tab, and matches the worst individual target alignment error shown in that tab.    While this is technically an \"alignment\" error, use of the term \"calibration\" is historical.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetCalibrationErrorExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | client projector info DTO

            try
            {
                // Retrieves the current alignment error of the specified projector to its observable alignment targets.
                ResultDtoDouble result = apiInstance.CoreLaserServiceGetCalibrationError(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceGetCalibrationError: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **clientProjectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| client projector info DTO | 

### Return type

[**ResultDtoDouble**](ResultDtoDouble.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetmodelposition"></a>
# **CoreLaserServiceGetModelPosition**
> ResultDtoModelPositionDto CoreLaserServiceGetModelPosition (ClientProjectorInfoDto clientProjectorInfo)

Returns model (tool) location and orientation in projector coordinates.

Returns x,y,z projector space coordinates of the model (tool) origin (in FEET), and rotation (in radians) about each of the x,y and z axes for orientation.   If the projector is not been aligned in this Work Order then any position/orientation returned by this method is to be disregarded.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetModelPositionExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns model (tool) location and orientation in projector coordinates.
                ResultDtoModelPositionDto result = apiInstance.CoreLaserServiceGetModelPosition(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceGetModelPosition: " + e.Message );
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

[**ResultDtoModelPositionDto**](ResultDtoModelPositionDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectoralignmentstate"></a>
# **CoreLaserServiceGetProjectorAlignmentState**
> ResultDtoProjectorAlignmentState CoreLaserServiceGetProjectorAlignmentState (ClientProjectorInfoDto projectorInfo)

Returns the Alignment Status of the specified projector.

Returns the projector's AlignmentState (also available from `/GetProjectorDescriptors`) See `ProjectorDescriptorDto` &gt; `AlignmentState` in the Integrators Guide.    ProjectorAlignmentState values indicating the specified projector's current state are as follows:  - (-1) Unknown  - The projector was not found in an open work order for the client id or an alignment attempt has not taken place  - ( 0) Error    - Alignment attempt has not succeeded; either targets could not be found or not scanned to within required tolerances (RED)  - ( 1) Aligning - LED flashes are in progress (if using vision capable projectors aka FlashAlign)  and/or lasers are scanning Work Order Tool targets. a projector in the midst of Manual Alignment will show this as well.  - ( 2) Aligned  - Lasers have aligned to the Work Order using the tool targets to within tolerance specifications (GREEN)  - ( 3) Warning  - Lasers have scanned tool targets, but the vision system is impaired (possibly CalibrationState=FailedCalibration) (YELLOW)  - ( 4) Excluded - The projector is excluded from participating in the Work Order (BLACK)

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorAlignmentStateExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var projectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | Contains the Client Id and the serial number of the projector.

            try
            {
                // Returns the Alignment Status of the specified projector.
                ResultDtoProjectorAlignmentState result = apiInstance.CoreLaserServiceGetProjectorAlignmentState(projectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceGetProjectorAlignmentState: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **projectorInfo** | [**ClientProjectorInfoDto**](ClientProjectorInfoDto.md)| Contains the Client Id and the serial number of the projector. | 

### Return type

[**ResultDtoProjectorAlignmentState**](ResultDtoProjectorAlignmentState.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicegetprojectorposition"></a>
# **CoreLaserServiceGetProjectorPosition**
> ResultDtoProjectorPositionDto CoreLaserServiceGetProjectorPosition (ClientProjectorInfoDto clientProjectorInfo)

Returns projector location and orientation in Work Order tool coordinates.

Returns x,y,z tool space coordinates of the specified projector (in FEET), and rotation (in radians) about each of the x,y and z axes for orientation.   If the projector is not been aligned in this Work Order then any position/orientation returned by this method is to be disregarded.

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceGetProjectorPositionExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var clientProjectorInfo = new ClientProjectorInfoDto(); // ClientProjectorInfoDto | 

            try
            {
                // Returns projector location and orientation in Work Order tool coordinates.
                ResultDtoProjectorPositionDto result = apiInstance.CoreLaserServiceGetProjectorPosition(clientProjectorInfo);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceGetProjectorPosition: " + e.Message );
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

[**ResultDtoProjectorPositionDto**](ResultDtoProjectorPositionDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserserviceinitializeprojectionandsetuptool"></a>
# **CoreLaserServiceInitializeProjectionAndSetupTool**
> ResultDto CoreLaserServiceInitializeProjectionAndSetupTool (InitializeProjectionAndSetupToolDto initializeProjectionAndSetupTool)

NOT SUPPORTED IN THIS VERSION - use /OpenTool

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceInitializeProjectionAndSetupToolExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var initializeProjectionAndSetupTool = new InitializeProjectionAndSetupToolDto(); // InitializeProjectionAndSetupToolDto | Stores Client ID and WorkOrder Name.

            try
            {
                // NOT SUPPORTED IN THIS VERSION - use /OpenTool
                ResultDto result = apiInstance.CoreLaserServiceInitializeProjectionAndSetupTool(initializeProjectionAndSetupTool);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceInitializeProjectionAndSetupTool: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **initializeProjectionAndSetupTool** | [**InitializeProjectionAndSetupToolDto**](InitializeProjectionAndSetupToolDto.md)| Stores Client ID and WorkOrder Name. | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

<a name="corelaserservicetargetprojection"></a>
# **CoreLaserServiceTargetProjection**
> ResultDto CoreLaserServiceTargetProjection (TargetProjectionDto targetProjectionDto)

Sets on/off \"Project All Targets\" or \"Show Labels\" for the specified projector.

Sets the projection of remembered target locations by a specific projector on (ProjectTargets=true) or off (false); same as clicking the \"Project All Targets\" button in the projector's Projector Dashboard &gt; Targets Tab. If ShowLabels is true, will also display the target name label as if the \"Show Labels\" checkbox was enabled under the Project All Targets button.   ShowLabels is ignored if `ProjectTargets=false`.  <example>              TargetProjectionDto {                  ClientInfo (ClientInfoDto, required),                  ProjectorSerial (string, required),                  ProjectTargets (boolean, required),                  ShowLabels (boolean, required)              }              ClientInfoDto {                  ClientId (string, required),                  OriginatingClientGuid (string, optional),                  Type (string, optional)              }              </example>

### Example
```csharp
using System;
using System.Diagnostics;
using VisionAndProjectionService.Swagger.Api;
using VisionAndProjectionService.Swagger.Client;
using VisionAndProjectionService.Swagger.Model;

namespace Example
{
    public class CoreLaserServiceTargetProjectionExample
    {
        public void main()
        {
            var apiInstance = new CalibrationApi();
            var targetProjectionDto = new TargetProjectionDto(); // TargetProjectionDto | 

            try
            {
                // Sets on/off \"Project All Targets\" or \"Show Labels\" for the specified projector.
                ResultDto result = apiInstance.CoreLaserServiceTargetProjection(targetProjectionDto);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling CalibrationApi.CoreLaserServiceTargetProjection: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **targetProjectionDto** | [**TargetProjectionDto**](TargetProjectionDto.md)|  | 

### Return type

[**ResultDto**](ResultDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

