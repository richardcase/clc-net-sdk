﻿using CenturyLinkCloudSDK.Services;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CenturyLinkCloudSDK.ServiceModels
{
    public class DataCenter
    {
        private Lazy<Link> computeLimitsLink;

        private Lazy<Link> billingLink;

        private Lazy<Link> rootGroupLink;

        public Authentication Authentication { get; set; }

        /// <summary>
        /// Default constructor.
        /// </summary>
        public DataCenter()
        {
            computeLimitsLink = new Lazy<Link>(() =>
            {
                return Links.FirstOrDefault(l => String.Equals(l.Rel, "computeLimits", StringComparison.CurrentCultureIgnoreCase));
            });

            billingLink = new Lazy<Link>(() =>
            {
                return Links.FirstOrDefault(l => String.Equals(l.Rel, "billing", StringComparison.CurrentCultureIgnoreCase));
            });

            rootGroupLink = new Lazy<Link>(() =>
            {
                return Links.FirstOrDefault(l => String.Equals(l.Rel, "group", StringComparison.CurrentCultureIgnoreCase));
            });
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public TotalAssets Totals { get; set; }

        [JsonPropertyAttribute]
        private IEnumerable<Link> Links { get; set; }

        /// <summary>
        /// Determines if this data center has compute limits based on the Links collection.
        /// </summary>
        private bool HasComputeLimits()
        {
            return computeLimitsLink.Value != null ? true : false;
        }

        /// <summary>
        /// Determines if this data center has billing details based on the Links collection.
        /// </summary>
        /// <returns></returns>
        private bool HasBillingDetails()
        {
            return billingLink.Value != null ? true : false;
        }

        /// <summary>
        /// Determines if this data center has a root group based on the links collection.
        /// </summary>
        /// <returns></returns>
        private bool HasRootGroup()
        {
            return rootGroupLink.Value != null ? true : false;
        }

        /// <summary>
        /// Gets the billing details.
        /// </summary>
        /// <returns></returns>
        public async Task<GroupBillingDetail> GetBillingDetails()
        {
            return await GetBillingDetails(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the billing details.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<GroupBillingDetail> GetBillingDetails(CancellationToken cancellationToken)
        {
            if(!HasBillingDetails())
            {
                return null;
            }

            var billingService = new BillingService(Authentication);
            var billingDetails = await billingService.GetGroupBillingDetailsByLink(string.Format("{0}{1}", Configuration.BaseUri, billingLink.Value.Href), cancellationToken).ConfigureAwait(false);
            return billingDetails;
        }

        /// <summary>
        /// Gets the billing totals.
        /// </summary>
        /// <returns></returns>
        public async Task<BillingDetail> GetBillingTotals()
        {
            return await GetBillingTotals(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the billing totals.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<BillingDetail> GetBillingTotals(CancellationToken cancellationToken)
        {
            if (!HasBillingDetails())
            {
                return null;
            }

            var billingService = new BillingService(Authentication);
            var billingTotals = await billingService.GetGroupBillingTotalsByLink(string.Format("{0}{1}", Configuration.BaseUri, billingLink.Value.Href), cancellationToken).ConfigureAwait(false);
            return billingTotals;
        }

        /// <summary>
        /// Gets the compute limits.
        /// </summary>
        /// <returns></returns>
        public async Task<ComputeLimits> GetComputeLimits()
        {
            return await GetComputeLimits(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the compute limits.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<ComputeLimits> GetComputeLimits(CancellationToken cancellationToken)
        {
            if(!HasComputeLimits())
            {
                return null;
            }

            var dataCenterService = new DataCenterService(Authentication);
            var computeLimits = await dataCenterService.GetComputeLimitsByLink(string.Format("{0}{1}", Configuration.BaseUri, computeLimitsLink.Value.Href), cancellationToken).ConfigureAwait(false);
            return computeLimits;
        }

        /// <summary>
        /// Gets the root group.
        /// </summary>
        /// <returns></returns>
        public async Task<Group> GetRootGroup()
        {
            return await GetRootGroup(CancellationToken.None).ConfigureAwait(false);
        }

        /// <summary>
        /// Gets the root group.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<Group> GetRootGroup(CancellationToken cancellationToken)
        {
            if (!HasRootGroup())
            {
                return null;
            }

            var dataCenterService = new DataCenterService(Authentication);
            var rootGroup = await dataCenterService.GetRootGroupByLink(string.Format("{0}{1}", Configuration.BaseUri, rootGroupLink.Value.Href), cancellationToken).ConfigureAwait(false);
            return rootGroup;
        }
    }
}
