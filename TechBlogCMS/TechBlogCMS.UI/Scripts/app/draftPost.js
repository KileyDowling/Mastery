$('#create').click(function () {
    validate({
        rules: {
            DateOfPost: {
                required: true,
                date: true
            },
            PostTitle: "required",
            PostContent: "required"
        },
        messages: {
            DateOfPost: "Please enter a valid date",
            PostTitle: "Please enter a title",
            PostContent: "Please provide content"
        }

    });
});