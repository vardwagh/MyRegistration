$(document).ready(function () {
    $(function () {
        $("#txtDOB").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'x_office_calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'dd-mm-yy',
            maxDate: '-18Y'
        }).attr('readonly', 'readonly');

        $("#txtDOJ").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'x_office_calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'dd-mm-yy'
        }).attr('readonly', 'readonly');

        $("#txtSpouceDOB").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'x_office_calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'dd-mm-yy',
            maxDate: '-18Y'

        }).attr('readonly', 'readonly');
        $(".datepicker").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'x_office_calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'dd-mm-yy',
            maxDate: '-0'
        }).attr('readonly', 'readonly');

        $(".datepicker1").datepicker({
            showOn: 'button',
            buttonImageOnly: true,
            buttonImage: 'x_office_calendar.png',
            changeMonth: true,
            changeYear: true,
            showAnim: 'slideDown',
            duration: 'fast',
            dateFormat: 'dd-mm-yy',
            maxDate: '-20Y'
        }).attr('readonly', 'readonly');

        $('#cblChild input[type="checkbox"]').click(function (e) {
            if ($("#cblChild").children().find('input[type="checkbox"]:checked').length > 2) {
                e.preventDefault();
                alert('Only 2 Child allowed');
            }
        });

        $('#cblParent input[type="checkbox"]').click(function (e) {
            if ($("#cblParent").children().find('input[type="checkbox"]:checked').length > 2) {
                e.preventDefault();
                alert('Only 2 Parents allowed');
            }
        });

    });
});
