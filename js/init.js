(function () {

    $(document).ready(function () {

        Materialize.updateTextFields();

        $('#ddlTipoUsuario').change(function () {
            $('#ddlTipoUsuario').material_select();
        })

        if ($('.slider').length > 0) {
            $('.slider').slider();
        }

        if($('.modal').length > 0){
            $('.modal').modal();
        }

        if ($(".button-collapse").length > 0) {
            $(".button-collapse").sideNav();
        }

        if ($('select').length > 0) {
            $('select').material_select();
        }

        if ($(".btnModificar").length > 0) {
            $(".btnModificar").html("<i class='material-icons edit'>edit</i>");
        }

        if($(".eliminarModal").length > 0){
            $(".eliminarModal").html("<i class='material-icons delete'>delete</i>");
        }

        if($(".iconSee").length > 0){
            $(".iconSee").html("<i class='material-icons'>visibility</i>");
        }

        if ($(".btnIncidente")) {
            $(".btnIncidente").html("<i class='material-icons'>done_all</i>");
        }
        
        if ($('.dropdown-button').length > 0) {
            $('.dropdown-button').dropdown({
                constrainWidth: false, // Does not change width of dropdown to that of the activator
                gutter: 0, // Spacing from edge
                belowOrigin: true, // Displays dropdown below the button
                alignment: 'right', // Displays dropdown with edge aligned to the left of button
                stopPropagation: false // Stops event propagation
            });
        }

        if ($('.datepicker').length > 0) {
            $('.datepicker').pickadate({
                monthsFull: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio', 'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                monthsShort: ['ene', 'feb', 'mar', 'abr', 'may', 'jun', 'jul', 'ago', 'sep', 'oct', 'nov', 'dic'],
                weekdaysFull: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                weekdaysShort: ['dom', 'lun', 'mar', 'mié', 'jue', 'vie', 'sáb'],
                today: 'Hoy',
                clear: 'Borrar',
                close: 'Cerrar',
                firstDay: 1,
                format: 'yyyy-mm-dd',
                formatSubmit: 'yyyy-mm-dd',

                selectMonths: true, // Creates a dropdown to control month
                selectYears: 100 // Creates a dropdown of 15 years to control year
            });
        }

        if ($('#user_nav').length > 0) {
            $('#user_nav li a').each((i, el) => {
                if ($(el).attr('href') == location.pathname) {
                    if($(el).parent().parent().parent().hasClass('collapsible-body')){
                        // $(el).parent().parent().parent().parent().parent().parent().trigger('click');
                        // console.log($(el).parent().parent().parent().parent().onclick);
                    }
                    $(el).parent().addClass('active');   
                }
            })
        }

        if($(".btnUnlog").length > 0 ){
            $(".btnUnlog").click(function(){
                $.ajax({
                    type: 'POST',
                    url: '/Services/CerrarSesion.svc/Cerrar',
                    cache: true,
                    asyc: false,
                    data: "{}",
                    contentType: 'application/json; charset=utf-8',
                    dataType: 'json',
                    success: function (r) {
                        location.href = '/';
                    }
                })
            })
        }
        
    })

})();