﻿using System;

namespace Imgur.API.Models
{
    /// <summary>
    ///     The base model for a message from account notifications.
    /// </summary>
    public interface IMessage : IDataModel
    {
        /// <summary>
        ///     Account ID of the user in conversation.
        /// </summary>
        int AccountId { get; set; }

        /// <summary>
        ///     Utc timestamp of last sent message, converted from epoch time.
        /// </summary>
        DateTimeOffset DateTime { get; set; }

        /// <summary>
        ///     The username of the other user in conversation.
        /// </summary>
        string From { get; set; }

        /// <summary>
        ///     Conversation ID
        /// </summary>
        int Id { get; set; }

        /// <summary>
        ///     The last message
        /// </summary>
        string LastMessage { get; set; }

        /// <summary>
        ///     Total number of messages in the conversation.
        /// </summary>
        int MessageNum { get; set; }

        /// <summary>
        ///     Account ID of the other user in conversation.
        /// </summary>
        int WithAccountId { get; set; }
    }
}