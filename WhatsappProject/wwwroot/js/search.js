﻿$(function () {
    $('form').submit(async e => {
       e.preventDefault();
        const q = $('#search').val();
        $('#tbodyid').load('/Rating/Search1?query=' + q);
    })
    
});