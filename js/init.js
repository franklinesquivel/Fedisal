(function () {

    $(document).ready(function () {

        if ($('.slider').length > 0) {
            $('.slider').slider();
        }

        if ($(".button-collapse").length > 0) {
            $(".button-collapse").sideNav();
        }

        if ($('select').length > 0) {
            $('select').material_select();
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
        
    })

})();