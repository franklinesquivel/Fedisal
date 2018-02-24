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
        
    })

})();