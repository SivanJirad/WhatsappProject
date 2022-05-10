$(function () {
   
    $('form').submit(async e => {
       e.preventDefault();
    
        const q = $('#search').val();
        console.log('/Rating/Search2?query=' + q);
        //$('#tbodyid').empty;
        $('#tbodyid').load('/Rating/Search2?query=' + q);

        //https://localhost:7038/rating/search2?query=a
        /*
        const response = await fetch('/Rating/Search2?query=' + q)
        
        var data = await response.json();

        $('tbody').html(results);



        const template = $('#template').html();
        let results = '';
        for (var index in d) {
            let row = template;
            for (var key in d[index]) {
                console.log(key , d[item][key]);
                row = row.replace('{' + key + '}', d[index][key]);
                row = row.replace('%7B' + key + '%7D', d[index][key]);

            }
            result += row;
        }
        $('tbody').html(results);
        */
        
    })
    
});