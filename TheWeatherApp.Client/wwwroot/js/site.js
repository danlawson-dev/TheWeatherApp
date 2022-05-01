$(document).ready(function () {
    // We need to check on page load if the textbox already has text in
    UpdateWeatherLocationFormButton();

    // When typing into the weather location form textbox, check if the button should show as disabled or enabled
    $('.weather-location-form-input').keyup(function () {
        UpdateWeatherLocationFormButton();
    });

    function UpdateWeatherLocationFormButton() {
        if ($('.weather-location-form-input').val() == '') {
            $('.weather-location-form-button').addClass('disabled');
        }
        else {
            $('.weather-location-form-button').removeClass('disabled');
        }
    }

    $('.weather-location-form-input').keyup(function () {
        // If the user presses 'enter' key AND there is a value in the textbox
        // Then trigger the button click to make the API POST request
        if (event.keyCode == 13 && $(this).val() != '') {
            event.preventDefault();
            $('.weather-location-form-button').trigger('click');
        }
    });

    $('.weather-location-form-button').click(function () {
        // Add a spinner while we do the AJAX call
        $('.weather-location-form-result').html('<div class="spinner-border"></div>');

        // Make the POST request
        $.ajax({
            url: $(this).attr('click-target'),
            type: 'POST',
            data: {
                location: $('.weather-location-form-input').val()
            },
            success: function (result) {
                // API will always return successful with a partial view to update the container
                $('.weather-location-form-result').html(result);

                // Bind the temperature toggle buttons
                $('.celcius-toggle-button').bind('click', function () {
                    UpdateTemperatureValuesShow(true);
                });

                $('.fahrenheit-toggle-button').bind('click', function () {
                    UpdateTemperatureValuesShow(false);
                });

                // Default to always show Celcius temperate values first
                UpdateTemperatureValuesShow(true);
            }
        });
    });

    function UpdateTemperatureValuesShow(showCelcius) {
        if (showCelcius) {
            $('.fahrenheit-value').hide();
            $('.celcius-value').show();
            $('.fahrenheit-toggle-button').show();
            $('.celcius-toggle-button').hide();
        }
        else {
            $('.celcius-value').hide();
            $('.fahrenheit-value').show();
            $('.celcius-toggle-button').show();
            $('.fahrenheit-toggle-button').hide();
        }
    }
});