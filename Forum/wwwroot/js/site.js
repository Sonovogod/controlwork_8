$.ajaxSetup({
    headers: {'RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()}
});

$(document).ready(() => {
    $('#commentThemeBtn').on('click', function (event){
        event.preventDefault();
        const themeId = $(this).attr('themeId');
        const userName = $(this).attr('userName');
        const comment = $('#commentTheme').val().trim();
        console.log(comment)
        const createCommentViewModel = {
            userName: userName,
            content: comment,
            themeId: themeId
        }
        
        if (comment.length !== 0){
            $.ajax({
                type: 'POST',
                url: '/Themes/CommentTheme/',
                data: createCommentViewModel,
                success: function (response){
                    const avatar = response.avatar;
                    const userName = response.userName;
                    const content = response.comment;
                    const date = response.dateOfCreate;
                    
                    const newComment = 
                        $('<div class="media row">\n' +
        '                    <img src="' + avatar + '" class="mr-3 rounded-circle" alt="' + userName + '">\n' +
        '                    <div class="media-body">\n' +
        '                        <h5 class="mt-0">' + userName + '</h5>\n' +
        '                        <p>' + content + '</p>\n' +
        '                        <small class="text-muted">' + date + '</small>\n' +
        '                    </div>\n' +
        '                </div>');
                    $('#commentContainer').after(
                        newComment
                    )
                },
                error: function (response) {
                    console.log(response);
                }
            })
        }
        else {
            console.log("Коммент пустой")
        }
    })
});
