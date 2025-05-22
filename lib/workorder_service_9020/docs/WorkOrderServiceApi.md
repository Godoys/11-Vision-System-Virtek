# WorkorderService.Swagger.Api.WorkOrderServiceApi

All URIs are relative to *http://localhost:9020*

Method | HTTP request | Description
------------- | ------------- | -------------
[**WorkOrderServiceDownloadWoCad**](WorkOrderServiceApi.md#workorderservicedownloadwocad) | **POST** /DownloadWOCAD | Returns a websocket from which you can download the Work Order&#39;s CAD file from the WORK ORDER Service.


<a name="workorderservicedownloadwocad"></a>
# **WorkOrderServiceDownloadWoCad**
> ResultDtoFileDownloadDto WorkOrderServiceDownloadWoCad (LoadWorkOrderDto workOrderName)

Returns a websocket from which you can download the Work Order's CAD file from the WORK ORDER Service.

Opens a socket at the Port specified at the Work Order service (not the CAD Service)   to download the CAD file associated with the specified Work Order. Once opened bytes of the CAD file  are read from that port until `FileSize` bytes are reached.  The FileName is for reference only, as it is know to the CAD and Work Order services.   ClientID and ClientConfigurationProfileName, if provided are ignored.    When a Work Order CAD file is opened in Iris Client, the Work Order and CAD Services convert the original CAD file  into an intermediary Standard ACIS Binary (.sab) file which is cached within the Work Order folder.   This conversion can also be triggered with the `/TranslateCad` endpoint in CAD service.     If this conversion has been performed, that .sab file will be the one provided.   If not, the original CAD file - in its original format - will be provided.

### Example
```csharp
using System;
using System.Diagnostics;
using WorkorderService.Swagger.Api;
using WorkorderService.Swagger.Client;
using WorkorderService.Swagger.Model;

namespace Example
{
    public class WorkOrderServiceDownloadWoCadExample
    {
        public void main()
        {
            var apiInstance = new WorkOrderServiceApi();
            var workOrderName = new LoadWorkOrderDto(); // LoadWorkOrderDto | 

            try
            {
                // Returns a websocket from which you can download the Work Order's CAD file from the WORK ORDER Service.
                ResultDtoFileDownloadDto result = apiInstance.WorkOrderServiceDownloadWoCad(workOrderName);
                Debug.WriteLine(result);
            }
            catch (Exception e)
            {
                Debug.Print("Exception when calling WorkOrderServiceApi.WorkOrderServiceDownloadWoCad: " + e.Message );
            }
        }
    }
}
```

### Parameters

Name | Type | Description  | Notes
------------- | ------------- | ------------- | -------------
 **workOrderName** | [**LoadWorkOrderDto**](LoadWorkOrderDto.md)|  | 

### Return type

[**ResultDtoFileDownloadDto**](ResultDtoFileDownloadDto.md)

### Authorization

No authorization required

### HTTP request headers

 - **Content-Type**: application/json, text/json, text/html, application/xml, text/xml, application/x-www-form-urlencoded
 - **Accept**: application/json, text/json, text/html, application/xml, text/xml

[[Back to top]](#) [[Back to API list]](../README.md#documentation-for-api-endpoints) [[Back to Model list]](../README.md#documentation-for-models) [[Back to README]](../README.md)

