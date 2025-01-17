// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Core;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Compute
{
    /// <summary> A class representing collection of OSVersion and their operations over its parent. </summary>
    public partial class OSVersionCollection : ArmCollection, IEnumerable<OSVersion>, IAsyncEnumerable<OSVersion>
    {
        private readonly ClientDiagnostics _oSVersionCloudServiceOperatingSystemsClientDiagnostics;
        private readonly CloudServiceOperatingSystemsRestOperations _oSVersionCloudServiceOperatingSystemsRestClient;
        private readonly string _location;

        /// <summary> Initializes a new instance of the <see cref="OSVersionCollection"/> class for mocking. </summary>
        protected OSVersionCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="OSVersionCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        /// <param name="location"> Name of the location that the OS versions pertain to. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="location"/> is null. </exception>
        internal OSVersionCollection(ArmClient client, ResourceIdentifier id, string location) : base(client, id)
        {
            _location = location;
            _oSVersionCloudServiceOperatingSystemsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Compute", OSVersion.ResourceType.Namespace, DiagnosticOptions);
            Client.TryGetApiVersion(OSVersion.ResourceType, out string oSVersionCloudServiceOperatingSystemsApiVersion);
            _oSVersionCloudServiceOperatingSystemsRestClient = new CloudServiceOperatingSystemsRestOperations(_oSVersionCloudServiceOperatingSystemsClientDiagnostics, Pipeline, DiagnosticOptions.ApplicationId, BaseUri, oSVersionCloudServiceOperatingSystemsApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != Subscription.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, Subscription.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public async virtual Task<Response<OSVersion>> GetAsync(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.Get");
            scope.Start();
            try
            {
                var response = await _oSVersionCloudServiceOperatingSystemsRestClient.GetOSVersionAsync(Id.SubscriptionId, _location, osVersionName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw await _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateRequestFailedExceptionAsync(response.GetRawResponse()).ConfigureAwait(false);
                return Response.FromValue(new OSVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets properties of a guest operating system version that can be specified in the XML service configuration (.cscfg) for a cloud service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public virtual Response<OSVersion> Get(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.Get");
            scope.Start();
            try
            {
                var response = _oSVersionCloudServiceOperatingSystemsRestClient.GetOSVersion(Id.SubscriptionId, _location, osVersionName, cancellationToken);
                if (response.Value == null)
                    throw _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateRequestFailedException(response.GetRawResponse());
                return Response.FromValue(new OSVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of all guest operating system versions available to be specified in the XML service configuration (.cscfg) for a cloud service. Use nextLink property in the response to get the next page of OS versions. Do this till nextLink is null to fetch all the OS versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions
        /// Operation Id: CloudServiceOperatingSystems_ListOSVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="OSVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<OSVersion> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<OSVersion>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _oSVersionCloudServiceOperatingSystemsRestClient.ListOSVersionsAsync(Id.SubscriptionId, _location, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OSVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<OSVersion>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _oSVersionCloudServiceOperatingSystemsRestClient.ListOSVersionsNextPageAsync(nextLink, Id.SubscriptionId, _location, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new OSVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a list of all guest operating system versions available to be specified in the XML service configuration (.cscfg) for a cloud service. Use nextLink property in the response to get the next page of OS versions. Do this till nextLink is null to fetch all the OS versions.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions
        /// Operation Id: CloudServiceOperatingSystems_ListOSVersions
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="OSVersion" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<OSVersion> GetAll(CancellationToken cancellationToken = default)
        {
            Page<OSVersion> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _oSVersionCloudServiceOperatingSystemsRestClient.ListOSVersions(Id.SubscriptionId, _location, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OSVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<OSVersion> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _oSVersionCloudServiceOperatingSystemsRestClient.ListOSVersionsNextPage(nextLink, Id.SubscriptionId, _location, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new OSVersion(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public async virtual Task<Response<bool>> ExistsAsync(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = await GetIfExistsAsync(osVersionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public virtual Response<bool> Exists(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.Exists");
            scope.Start();
            try
            {
                var response = GetIfExists(osVersionName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public async virtual Task<Response<OSVersion>> GetIfExistsAsync(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _oSVersionCloudServiceOperatingSystemsRestClient.GetOSVersionAsync(Id.SubscriptionId, _location, osVersionName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return Response.FromValue<OSVersion>(null, response.GetRawResponse());
                return Response.FromValue(new OSVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// Request Path: /subscriptions/{subscriptionId}/providers/Microsoft.Compute/locations/{location}/cloudServiceOsVersions/{osVersionName}
        /// Operation Id: CloudServiceOperatingSystems_GetOSVersion
        /// </summary>
        /// <param name="osVersionName"> Name of the OS version. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="osVersionName"/> is empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="osVersionName"/> is null. </exception>
        public virtual Response<OSVersion> GetIfExists(string osVersionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(osVersionName, nameof(osVersionName));

            using var scope = _oSVersionCloudServiceOperatingSystemsClientDiagnostics.CreateScope("OSVersionCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _oSVersionCloudServiceOperatingSystemsRestClient.GetOSVersion(Id.SubscriptionId, _location, osVersionName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return Response.FromValue<OSVersion>(null, response.GetRawResponse());
                return Response.FromValue(new OSVersion(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<OSVersion> IEnumerable<OSVersion>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<OSVersion> IAsyncEnumerable<OSVersion>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
