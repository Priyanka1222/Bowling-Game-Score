var bonusDelivery = document.getElementById('Frames_9__FirstDelivery');
var bonusDelivery2 = document.getElementById('Frames_9__SecondDelivery');

var showBonusDelivery = document.getElementById('showBonusDelivery');

var addFirstDelivery = [];

for (var i = 0; i <= 9; i++) {
    addFirstDelivery[i] = document.getElementById("Frames_" + i + "__FirstDelivery");
}

function Delivery() {
    for (var i = 0; i <= 9; i++) {

        var firstDelivery = addFirstDelivery[i].value;

        if (firstDelivery == 10) {

            second[i].style.visibility = 'hidden';
        }
        else {
            second[i].style.visibility = 'visible';
        }
    }
}

for (var i = 0; i <= 9; i++) {
    addFirstDelivery[i].onchange = Delivery;
    addFirstDelivery[i].onblur = Delivery;
}

function useBonusDelivery() {

    var firstDelivery = bonusDelivery.value;
    var secondDelivery = bonusDelivery2.value;


    var totalScore = Number(firstDelivery) + Number(secondDelivery);

    if (firstDelivery == 10) {
        showBonusDelivery.style.visibility = 'visible';
    }
    else if (totalScore == 10) {
        showBonusDelivery.style.visibility = 'visible';
    }
    else {
        showBonusDelivery.style.visibility = 'hidden';
    }
}
bonusDelivery.onchange = useBonusDelivery;
bonusDelivery.onblur = useBonusDelivery;