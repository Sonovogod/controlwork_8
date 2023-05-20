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
                    const content = response.content;
                    const date = response.date;
                    console.log(content);
                    console.log(date);
                    
                    const newComment = 
                        $('<div class="media row mt-5">\n' +
        '                    <div class="col-2">\n' +
        '                        <div class="mr-3 rounded-circle border border-dark border-1">\n' +
        '                            <img class="w-100 mr-3 rounded-circle" src="' +avatar+ '" alt="' +userName+ '">\n' +
        '                        </div>\n' +
        '                        <h5 class="mt-1 mx-2">' +userName+ '</h5>\n' +
        '                    </div>\n' +
        '                    <div class="col-8 px-2">\n' +
        '                        <small class="text-muted">' +date+ '</small>\n' +
        '                        <div class="w-50">\n' +
        '                            <span>' +content+ '</span>\n' +
        '                        </div>\n' +
        '                    </div>\n' +
        '                </div>');
                    $('#commetBlock').append(
                        newComment
                    );
                    $('#commentTheme').val('');
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
    $('#prevPageButton').on('click', function (event){
        event.preventDefault();
        const themeId = $(this).attr('themId');
        const currentPage = $(this).attr('currentPage');

        
    })
});

