﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Imgur.API.Authentication.Impl;
using Imgur.API.Endpoints;
using Imgur.API.Endpoints.Impl;
using Imgur.API.Helpers;
using Imgur.API.Models;
using Imgur.API.Models.Impl;
using Imgur.API.Tests.EndpointResponses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NSubstitute;

namespace Imgur.API.Tests.Endpoints
{
    [TestClass]
    public class AccountEndpointTests
    {
        private ImageHelper ImageHelper { get; } = new ImageHelper();

        [TestMethod]
        public void GetAccountAsync_WithUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountAsync("Bob");
            endpoint.Received().GetAccountAsync("Bob");
        }

        [TestMethod]
        public void GetAccountAsync_WithDefaultUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountAsync();
            endpoint.Received().GetAccountAsync("me");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountAsync_WithNullUsername_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountAsync_WithDefaultUsernameAndOAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountAsync();
        }

        [TestMethod]
        public void GetAccountAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var account = endpoint.ProcessEndpointResponse<Account>(AccountEndpointResponses.Imgur.GetAccountResponse);

            Assert.AreEqual(12456, account.Id);
            Assert.AreEqual("Bob", account.Url);
            Assert.AreEqual(null, account.Bio);
            Assert.AreEqual(4343, account.Reputation);
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1229591601), account.Created);
        }

        [TestMethod]
        public void GetAccountGalleryFavoritesAsync_WithUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountGalleryFavoritesAsync("Bob");
            endpoint.Received().GetAccountGalleryFavoritesAsync("Bob");
        }

        [TestMethod]
        public void GetAccountGalleryFavoritesAsync_WithDefaultUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountGalleryFavoritesAsync();
            endpoint.Received().GetAccountGalleryFavoritesAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountGalleryFavoritesAsync_WithNullUsername_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountGalleryFavoritesAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountGalleryFavoritesAsync_WithDefaultUsernameAndOAuth2NotSet_ThrowsArgumentNullException
            ()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountGalleryFavoritesAsync();
        }

        [TestMethod]
        public void GetAccountGalleryFavoritesAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var favorites =
                endpoint.ProcessEndpointResponse<IEnumerable<object>>(
                    AccountEndpointResponses.Imgur.GetAccountGalleryFavoritesResponse);

            Assert.AreEqual(favorites.Count(), ImageHelper.ConvertToGalleryItems(favorites).Count());
        }

        [TestMethod]
        public void GetAccountFavoritesAsync_WithUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountFavoritesAsync();
            endpoint.Received().GetAccountFavoritesAsync();
        }

        [TestMethod]
        public void GetAccountFavoritesAsync_WithDefaultUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountFavoritesAsync();
            endpoint.Received().GetAccountFavoritesAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountFavoritesAsync_WithDefaultUsernameAndOAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountFavoritesAsync();
        }

        [TestMethod]
        public void GetAccountFavoritesAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var favorites =
                endpoint.ProcessEndpointResponse<IEnumerable<object>>(
                    AccountEndpointResponses.Imgur.GetAccountFavoritesResponse);

            Assert.AreEqual(favorites.Count(), ImageHelper.ConvertToGalleryItems(favorites).Count());
        }

        [TestMethod]
        public void GetAccountSubmissionsAsync_WithUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountSubmissionsAsync("Bob");
            endpoint.Received().GetAccountSubmissionsAsync("Bob");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountSubmissionsAsync_WithDefaultUsernameAndOAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountSubmissionsAsync();
        }

        [TestMethod]
        public void GetAccountSubmissionsAsync_WithDefaultUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountSubmissionsAsync();
            endpoint.Received().GetAccountSubmissionsAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountSubmissionsAsync_WithNullUsername_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountSubmissionsAsync(null);
        }

        [TestMethod]
        public void GetAccountSubmissionsAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var submissions =
                endpoint.ProcessEndpointResponse<IEnumerable<object>>(
                    AccountEndpointResponses.Imgur.GetAccountSubmissionsResponse);

            Assert.AreEqual(submissions.Count(), ImageHelper.ConvertToGalleryItems(submissions).Count());
        }

        [TestMethod]
        public void GetAccountSettingsAsync_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetAccountSettingsAsync();
            endpoint.Received().GetAccountSettingsAsync();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetAccountSettingsAsync_OAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetAccountSettingsAsync();
        }

        [TestMethod]
        public void GetAccountSettingsAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var accountSettings =
                endpoint.ProcessEndpointResponse<AccountSettings>(
                    AccountEndpointResponses.Imgur.GetAccountSettingsResponse);

            Assert.AreEqual(true, accountSettings.AcceptedGalleryTerms);
            Assert.AreEqual("ImgurApiTest@noreply.com", accountSettings.ActiveEmails.First());
            Assert.AreEqual(AlbumPrivacy.Secret, accountSettings.AlbumPrivacy);
            Assert.AreEqual(45454554, accountSettings.BlockedUsers.First().BlockedId);
            Assert.AreEqual("Bob", accountSettings.BlockedUsers.First().BlockedUrl);
            Assert.AreEqual("ImgurApiTest@noreply.com", accountSettings.Email);
            Assert.AreEqual(false, accountSettings.HighQuality);
            Assert.AreEqual(true, accountSettings.MessagingEnabled);
            Assert.AreEqual(false, accountSettings.PublicImages);
            Assert.AreEqual(true, accountSettings.ShowMature);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task UpdateAccountSettings_OAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.UpdateAccountSettingsAsync("1234");
        }

        [TestMethod]
        public void UpdateAccountSettingsAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var updated = endpoint.ProcessEndpointResponse<bool>(
                    AccountEndpointResponses.Imgur.UpdateAccountSettingsResponse);

            Assert.IsTrue(updated);
        }

        [TestMethod]
        public void GetGalleryProfileAsync_WithUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetGalleryProfileAsync("Bob");
            endpoint.Received().GetGalleryProfileAsync("Bob");
        }
        
        [TestMethod]
        public void GetGalleryProfileAsync_WithDefaultUsername_ReceivedIsTrue()
        {
            var endpoint = Substitute.For<IAccountEndpoint>();
            endpoint.GetGalleryProfileAsync();
            endpoint.Received().GetGalleryProfileAsync("me");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetGalleryProfileAsync_WithNullUsername_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetGalleryProfileAsync(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task GetGalleryProfileAsync_WithDefaultUsernameAndOAuth2NotSet_ThrowsArgumentNullException()
        {
            var imgurAuth = new ImgurClient("123", "1234");
            var endpoint = new AccountEndpoint(imgurAuth);
            await endpoint.GetGalleryProfileAsync();
        }

        [TestMethod]
        public void GetGalleryProfileAsync_WithValidReponse_AreEqual()
        {
            var endpoint = Substitute.ForPartsOf<EndpointBase>();
            var profile = endpoint.ProcessEndpointResponse<GalleryProfile>(AccountEndpointResponses.Imgur.GetGalleryProfileResponse);

            Assert.AreEqual(1470, profile.TotalGalleryComments);
            Assert.AreEqual(3068, profile.TotalGalleryFavorites);
            Assert.AreEqual(156, profile.TotalGallerySubmissions);

            var trophy = profile.Trophies.First(x => x.Data == "114377540");

            Assert.AreEqual("114377540", trophy.Data);
            Assert.AreEqual("/gallery/RdU6zgv/comment/114377540", trophy.DataLink);
            Assert.AreEqual("4852550", trophy.Id);
            Assert.AreEqual("Comment sparked a large reply thread.", trophy.Description);
            Assert.AreEqual("http://s.imgur.com/images/trophies/e8a901.png", trophy.Image);
            Assert.AreEqual("Conversation Starter", trophy.Name);
            Assert.AreEqual("ReplyThread", trophy.NameClean);
            Assert.AreEqual(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(1380321520), trophy.DateTime);
        }
    }
}