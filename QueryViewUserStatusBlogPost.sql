Select b.UserID, b.PostContent,b.StatusID,s.StatusType, b.DateOfPost, b.PostTitle, b.BlogPostID from Blogpost b inner join [Status] s  on b.StatusID= s.StatusID order by b.DateOfPost desc