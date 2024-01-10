$(document).foundation();
const stepMenuOne = document.querySelector('.formbold-step-menu1')
const stepMenuTwo = document.querySelector('.formbold-step-menu2')
const stepMenuThree = document.querySelector('.formbold-step-menu3')

const stepOne = document.querySelector('.formbold-form-step-1')
const stepTwo = document.querySelector('.formbold-form-step-2')
const stepThree = document.querySelector('.formbold-form-step-3')

const formSubmitBtn = document.querySelector('.formbold-btn')
const formBackBtn = document.querySelector('.formbold-back-btn')

formSubmitBtn.addEventListener("click", function (event) {
    event.preventDefault()
    if (stepMenuOne.className == 'formbold-step-menu1 active') {
        event.preventDefault()

        stepMenuOne.classList.remove('active')
        stepMenuTwo.classList.add('active')

        stepOne.classList.remove('active')
        stepTwo.classList.add('active')

        formBackBtn.classList.add('active')
        formBackBtn.addEventListener("click", function (event) {
            event.preventDefault()

            stepMenuOne.classList.add('active')
            stepMenuTwo.classList.remove('active')

            stepOne.classList.add('active')
            stepTwo.classList.remove('active')

            formBackBtn.classList.remove('active')

        })

    } else if (stepMenuTwo.className == 'formbold-step-menu2 active') {
        event.preventDefault()

        stepMenuTwo.classList.remove('active')
        stepMenuThree.classList.add('active')

        stepTwo.classList.remove('active')
        stepThree.classList.add('active')

        formBackBtn.classList.remove('active')
        formSubmitBtn.textContent = 'Submit'
    } else if (stepMenuThree.className == 'formbold-step-menu3 active') {
        document.querySelector('form').submit()
    }
})

$('#signin-form').on('submit', function (event) {
    var username = $('#username').val();
    var password = $('#password').val();

    if (!username || !password) {
        event.preventDefault();
        $('#signin-form').foundation('addErrorClasses', $('#signin-form input:invalid'));
    }
});
// toggle list vs card view
$(".option__button").on("click", function () {
    $(".option__button").removeClass("selected");
    $(this).addClass("selected");
    if ($(this).hasClass("option--grid")) {
        $(".results-section").attr("class", "results-section results--grid");
    } else if ($(this).hasClass("option--list")) {
        $(".results-section").attr("class", "results-section results--list");
    }
});
//show more rows
var shownDefault = 1
var numShown = shownDefault; // Initial rows shown & index
var $table = $('.tbl').find('tbody'); // tbody containing all the rows
var numRows = $table.find('tr').length; // Total # rows

var moretext = `Show more <i class="fa fa-angle-down" aria-hidden="true"></i>`;
var lesstext = `Show less <i class="fa fa-angle-up" aria-hidden="true"></i>`;

$(document).ready(function () {
    $table.find('tr:gt(' + (numShown - 1) + ')').hide()
    $('#btn1').click(function () {
        if (numShown === numRows) {
            // since we show all rows node, hiding some
            numShown = shownDefault;
            $table.find('tr:gt(' + (numShown - 1) + ')').hide()
            $('#btn1').html(moretext)
        } else {
            numShown = numRows;
            $('#btn1').html(lesstext)
        }
        $table.find('tr:lt(' + numShown + ')').show();
    });
});
//show more rows
var shownDefault2 = 1
var numShown2 = shownDefault2; // Initial rows shown & index
var $table2 = $('.tb2').find('tbody'); // tbody containing all the rows
var numRows2 = $table2.find('tr').length; // Total # rows

var moretext = `Show more <i class="fa fa-angle-down" aria-hidden="true"></i>`;
var lesstext = `Show less <i class="fa fa-angle-up" aria-hidden="true"></i>`;

$(document).ready(function () {
    $table2.find('tr:gt(' + (numShown2 - 1) + ')').hide()
    $('#btn2').click(function () {
        if (numShown2 === numRows2) {
            // since we show all rows node, hiding some
            numShown2 = shownDefault2;
            $table2.find('tr:gt(' + (numShown2 - 1) + ')').hide()
            $('#btn2').html(moretext)
        } else {
            numShown2 = numRows2;
            $('#btn2').html(lesstext)
        }
        $table2.find('tr:lt(' + numShown2 + ')').show();
    });
});

// qty button
var QtyInput = (function () {
    var $qtyInputs = $(".qty-input");

    if (!$qtyInputs.length) {
        return;
    }

    var $inputs = $qtyInputs.find(".product-qty");
    var $countBtn = $qtyInputs.find(".qty-count");
    var qtyMin = parseInt($inputs.attr("min"));
    var qtyMax = parseInt($inputs.attr("max"));

    $inputs.change(function () {
        var $this = $(this);
        var $minusBtn = $this.siblings(".qty-count--minus");
        var $addBtn = $this.siblings(".qty-count--add");
        var qty = parseInt($this.val());

        if (isNaN(qty) || qty <= qtyMin) {
            $this.val(qtyMin);
            $minusBtn.attr("disabled", true);
        } else {
            $minusBtn.attr("disabled", false);

            if (qty >= qtyMax) {
                $this.val(qtyMax);
                $addBtn.attr('disabled', true);
            } else {
                $this.val(qty);
                $addBtn.attr('disabled', false);
            }
        }
    });

    $countBtn.click(function () {
        var operator = this.dataset.action;
        var $this = $(this);
        var $input = $this.siblings(".product-qty");
        var qty = parseInt($input.val());

        if (operator == "add") {
            qty += 1;
            if (qty >= qtyMin + 1) {
                $this.siblings(".qty-count--minus").attr("disabled", false);
            }

            if (qty >= qtyMax) {
                $this.attr("disabled", true);
            }
        } else {
            qty = qty <= qtyMin ? qtyMin : (qty -= 1);

            if (qty == qtyMin) {
                $this.attr("disabled", true);
            }

            if (qty < qtyMax) {
                $this.siblings(".qty-count--add").attr("disabled", false);
            }
        }

        $input.val(qty);
    });
})();
// Sort by filter
(function ($) {
    "use strict";

    $.fn.numericFlexboxSorting = function (options) {
        const settings = $.extend({
            elToSort: ".profile"
        }, options);

        const $select = this;
        const ascOrder = (a, b) => a - b;
        const descOrder = (a, b) => b - a;

        $select.on("change", () => {
            const selectedOption = $select.find("option:selected").attr("data-sort");
            sortColumns(settings.elToSort, selectedOption);
        });

        function sortColumns(el, opt) {
            const attr = "data-" + opt.split(":")[0];
            const sortMethod = (opt.includes("asc")) ? ascOrder : descOrder;
            const sign = (opt.includes("asc")) ? "" : "-";

            const sortArray = $(el).map((i, el) => $(el).attr(attr)).sort(sortMethod);

            for (let i = 0; i < sortArray.length; i++) {
                $(el).filter(`[${attr}="${sortArray[i]}"]`).css("order", sign + sortArray[i]);
            }
        }

        return $select;
    };
})(jQuery);

// call the plugin
$(".b-select").numericFlexboxSorting();

//star icon
$(".fav").on("click", function () {
    var $this = $(this);
    $this.toggleClass("off");
});

//search icon
(function () {

    $("#cart").on("click", function () {
        $(".shopping-cart").fadeToggle("fast");
    });

})();

//Hide/show Button
$(".btn").click(function () {
    var label = $(".btn").text().trim();

    if (label == "Hide Products") {
        $(".btn").html(' Show Products <i class="fa fa-angle-down"></i>');
        $(".myText").hide();
    } else {
        $(".btn").html('Hide Products <i class="fa fa-angle-up"></i> ');
        $(".myText").show();
    }
});


//Shopping Cart
const removeButtons = document.querySelectorAll('.remove-item');
removeButtons.forEach(button => {
    button.addEventListener('click', () => {
        const li = button.parentNode.parentNode; // Get the parent li element
        li.remove(); // Remove the li element
    });
});

//Cart Close Button
$(document).ready(function () {
    $(".shopping-cart .cart-popup-footer button[data-close]").click(function () {
        $(".shopping-cart").fadeOut();
    });
});

//Customize Bundle Show More Button
function toggleItemDetails() {
    var itemDetailsText = document.querySelector('.item-details__text');
    var toggleBtn = document.querySelector('.item-details__toggle-btn');

    if (itemDetailsText.classList.contains('show-more')) {
        itemDetailsText.classList.remove('show-more');
        toggleBtn.innerHTML = 'Show more <i class="fa fa-angle-down" aria-hidden="true"></i>';
    } else {
        itemDetailsText.classList.add('show-more');
        toggleBtn.innerHTML = 'Show less <i class="fa fa-angle-up" aria-hidden="true"></i>';
    }
}


function toggleItemDetails1() {
    var itemDetailsText = document.querySelector('.item-details__text1');
    var toggleBtn = document.querySelector('.item-details__toggle-btn1');

    if (itemDetailsText.classList.contains('show-more')) {
        itemDetailsText.classList.remove('show-more');
        toggleBtn.innerHtml = 'Show more <i class="fa fa-angle-down" aria-hidden="true"></i>';
    } else {
        itemDetailsText.classList.add('show-more');
        toggleBtn.innerHtml = 'Show less <i class="fa fa-angle-up" aria-hidden="true"></i>';
    }
}

//Remove Button
function removeProfile() {
    var profile = document.querySelector('.product-container');
    profile.remove();
}

//change button color
function changePersonalize() {
    var personalize = document.getElementById("personalize");
    personalize.style.backgroundColor = "#fff";
    personalize.innerHTML = "PERSONALIZE & PROOF AGAIN";
    personalize.style.color = "#00bb31";
    personalize.style.border = "1px solid #00bb31"
}

//Search bar
$(document).ready(function () {
    // Hide the search dropdown by default
    $('.search-dropdown').hide();

    // Toggle the search dropdown when the search icon is clicked
    $('#search-icon').click(function () {
        $('.search-dropdown').toggle();
    });
});

//download button
function downloadImage() {
    var link = document.createElement('a');
    link.href = 'images/proof.png';
    link.download = 'proof.png';
    link.click();
}

//checkout bar
$('.btn-next').on('click', function () {

    var currentStepNum = $('#checkout-progress').data('current-step');
    var nextStepNum = (currentStepNum + 1);
    var currentStep = $('.step.step-' + currentStepNum);
    var nextStep = $('.step.step-' + nextStepNum);
    var progressBar = $('#checkout-progress');
    $('.btn-prev').removeClass('disabled');
    $('#section' + currentStepNum).toggle();
    $('#section' + nextStepNum).toggle();
    if (nextStepNum == 4) {
        $(this).toggle();
        $('.btn-submit').toggle();
    }
    /*if(nextStepNum == 5){
        $(this).addClass('disabled');
    }*/
    $('.checkout-progress').removeClass('.step-' + currentStepNum).addClass('.step-' + (currentStepNum + 1));

    currentStep.removeClass('active').addClass('valid');
    currentStep.find('span').addClass('opaque');
    currentStep.find('.fa.fa-check').removeClass('opaque');

    nextStep.addClass('active').addClass('valid');
    progressBar.removeAttr('class').addClass('step-' + nextStepNum).data('current-step', nextStepNum);
    window.scrollTo(0, 0);
});


$('.btn-submit').on('click', function () {
    $('.btn-submit').toggle('disabled');
    $('.btn-prev').toggle();
    var currentStepNum = $('#checkout-progress').data('current-step');
    var currentStep = $('.step.step-' + currentStepNum);
    currentStep.removeClass('active').addClass('valid');
    currentStep.find('.fa.fa-check').removeClass('opaque');
});
$('.btn-prev').on('click', function () {

    var currentStepNum = $('#checkout-progress').data('current-step');
    var prevStepNum = (currentStepNum - 1);
    var currentStep = $('.step.step-' + currentStepNum);
    var prevStep = $('.step.step-' + prevStepNum);
    var progressBar = $('#checkout-progress');
    $('.btn-next').removeClass('disabled');
    $('#section' + currentStepNum).toggle();
    $('#section' + prevStepNum).toggle();
    if (currentStepNum == 4) {
        $('.btn-submit').toggle();
        $('.btn-next').toggle();
    }
    if (currentStepNum == 1) {
        return false;
    }
    $('.checkout-progress').removeClass('.step-' + currentStepNum).addClass('.step-' + (prevStepNum));

    currentStep.removeClass('active');
    currentStep.removeClass('valid'); // added line to remove the "valid" class
    prevStep.find('span').removeClass('opaque');
    prevStep.find('.fa.fa-check').addClass('opaque');

    prevStep.addClass('active').addClass('valid');
    progressBar.removeAttr('class').addClass('step-' + prevStepNum).data('current-step', prevStepNum);

    $('.btn-next').show(); // added line to show the "next" button when going back to the first step

    if (prevStepNum == 1) {
        $(this).addClass('disabled');
    }
    window.scrollTo(0, 0);
});


//checkout section1
const checkboxes = document.querySelectorAll('.Table-row-item input[type="checkbox"]');

checkboxes.forEach((checkbox) => {
    checkbox.addEventListener('change', (event) => {
        const tableRow = event.target.closest('.Table-row');
        tableRow.classList.toggle('checked');
    });
});

//address popup in mobile view
function openPopup() {
    var popup = document.getElementById("popup");
    popup.style.display = "block";
    document.getElementById("popup-background").classList.add("popup-opened");

    // Add event listeners to the radio buttons
    var radioButtons = document.querySelectorAll('input[type="radio"]');
    for (var i = 0; i < radioButtons.length; i++) {
        radioButtons[i].addEventListener('change', onRadioSelected);
    }
}

function onRadioSelected(event) {
    // Get the selected shipping address
    var shippingAddress = event.target.nextElementSibling.textContent.trim();

    // Set the selected shipping address in the input field
    var input = document.querySelector('.shipping-address input[type="text"]');
    input.value = shippingAddress;

    // Close the popup
    closePopup();
}

function closePopup() {
    var popup = document.getElementById("popup");
    popup.style.display = "none";
    document.getElementById("popup-background").classList.remove("popup-opened");

    var selectedOption = document.querySelector('input[name="address"]:checked');
    if (selectedOption) {
        var shippingAddress = selectedOption.parentNode.textContent.trim();
        var input = document.querySelector('.shipping-address input[type="text"]');
        input.value = shippingAddress;
    }
}

//save button for profile page
// Wait for the document to be fully loaded
$(document).ready(function () {

    // When the Save button is clicked
    $(".save-button").click(function () {
        // Scroll to the top of the page
        window.scrollTo(0, 0);

        // Display the success message
        $(".success-message").fadeIn(500);

        // Hide the Save button
        $(this).fadeOut(500);

    });

});

//Profile address checkbox
const checkbox = document.querySelector('input[type="checkbox"]');
const shippingDiv = document.querySelector('.profile-page.shipping');

checkbox.addEventListener('change', () => {
    if (checkbox.checked) {
        shippingDiv.style.display = 'none';
    } else {
        shippingDiv.style.display = 'block';
    }
});


//order page data table
jQuery(document).ready(function ($) {
    $('#example').DataTable({
        language: {
            lengthMenu: "T'en veux _MENU_ par page",
            info: "T'es bigleux ? c'est la page _PAGE_ sur _PAGES_",
            search: "Cherche bouffon !",
            paginate: {
                first: "Premier",
                last: "Précédent",
                next: "Suivant",
                previous: "Dernier"
            }
        }
    });
}); //data table accordian
function toggleAccordion(rowId) {
    var content = document.getElementById(rowId);
    if (content.style.display === "none") {
        content.style.display = "block";
    } else {
        content.style.display = "none";
    }
}