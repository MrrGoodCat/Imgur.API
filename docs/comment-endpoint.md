# Comment Endpoint

##CreateCommentAsync
Creates a new comment, returns the ID of the comment. OAuth authentication required.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", YOUR_OAUTH2_TOKEN);
            var endpoint = new CommentEndpoint(client);
			var comment = await endpoint.CreateCommentAsync("YOUR_COMMENT", "IMAGE_ID");

##CreateReplyAsync
Create a reply for the given comment, returns the ID of the comment. OAuth authentication required.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", YOUR_OAUTH2_TOKEN);
            var endpoint = new CommentEndpoint(client);
			var comment = await endpoint.CreateReplyAsync(YOUR_COMMENT, "IMAGE_ID", "PARENT_ID");

##DeleteCommentAsync
Delete a comment by the given id. OAuth authentication required.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", YOUR_OAUTH2_TOKEN);
            var endpoint = new CommentEndpoint(client);
			var deleted = await endpoint.DeleteCommentAsync("COMMENT_ID");

##GetCommentAsync
Get information about a specific comment.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET");
            var endpoint = new CommentEndpoint(client);
			var comment = await endpoint.GetCommentAsync("COMMENT_ID");

##GetRepliesAsync
Get the comment with all of the replies for the comment.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET");
            var endpoint = new CommentEndpoint(client);
			var comment = await endpoint.GetRepliesAsync("COMMENT_ID");

##ReportCommentAsync
Report a comment for being inappropriate. OAuth authentication required.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", YOUR_OAUTH2_TOKEN);
            var endpoint = new CommentEndpoint(client);
			var reported = await endpoint.ReportCommentAsync("COMMENT_ID", REPORT_REASON);

##VoteCommentAsync
Vote on a comment. OAuth authentication required.

            var client = new ImgurClient("YOUR_CLIENT_ID", "YOUR_CLIENT_SECRET", YOUR_OAUTH2_TOKEN);
            var endpoint = new CommentEndpoint(client);
			var voted = await endpoint.VoteCommentAsync("COMMENT_ID", VOTE);