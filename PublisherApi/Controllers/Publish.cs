﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PublisherApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PublisherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Publish : ControllerBase
    {
       
        [AllowAnonymous]
        [HttpPost("publish")]
        public async Task<ActionResult> PublishAsync(Request request)
        {
            using var httpClient = new HttpClient();

            try
            {
                // Create the request payload
                var requestData = request.Data;
                var jsonPayload = System.Text.Json.JsonSerializer.Serialize(requestData);
                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Send a POST request to the API endpoint
                var response = await httpClient.PostAsync("http://192.168.1.29/PlancksoftPOSJSON/PlancksoftPOSJSON_Server.svc/" + request.Method, content);

                // Check if the response was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    var responseContent = await response.Content.ReadAsStringAsync();

                    // Process the response or deserialize it to your desired data type
                    return Ok(responseContent);
                }
                else
                {
                    // Handle the error case, if needed

                    return BadRequest($"Request failed with status code {response.RequestMessage}");
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that occurred during the request
                return BadRequest($"An error occurred: {ex.Message}");
            }
            
        }

        [AllowAnonymous]
        [HttpPost("publishInvoke")]
        public ActionResult publishInvoke(dynamic request)
        {


            // Step 1: Add a reference to the WCF service
            // Right-click on References > Add Service Reference
            // Enter the WCF service endpoint address and give it a name (e.g., MyWcfService)

            // Step 2: Create an instance of the WCF client
            var client = new PlancksoftPOSJSON_Server.PlancksoftPOSJSON_Server();

            var res = client.CheckConnection();
            // Step 3: Call the WCF service methods dynamically
            string methodName = "CheckConnection"; // Dynamically provided method name

            var method = typeof(PlancksoftPOSJSON_Server.PlancksoftPOSJSON_Server).GetMethod(methodName);
            if (method == null)
            {
                // Handle the case when the method is not found
                return NotFound();
            }

            var result = method.Invoke(client, null); // Invoke the method dynamically

            // Step 4: Map the retrieved data
            //var mappedData = MapToApiModel(result); // Perform any necessary mapping

            // Step 5: Return the data from your API endpoint
            return Ok(result); // Return the mapped data as the API response

        }
    }
}
