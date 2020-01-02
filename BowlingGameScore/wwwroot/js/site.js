var bonusDeliverie = document.getElementById('Deliveries_9__FirstDeliverie');
var bonusDeliverie2 = document.getElementById('Deliveries_9__SecondDeliverie');

var showBonusDeliverie = document.getElementById('showBonusDeliverie');
var showBonusDeliverie2 = document.getElementById('showBonusDeliverie2');

var addFirstDeliverie = [];

for (var i = 0; i <= 9; i++) {
    addFirstDeliverie[i] = document.getElementById("Deliveries_" + i + "__FirstDeliverie");
}

function Deliverie() {
    for (var i = 0; i <= 9; i++) {

        var firstDeliverie = addFirstDeliverie[i].value;

        if (firstDeliverie == 10) {

            second[i].style.visibility = 'hidden';
            SecondDeliverie = 0;
        }
        else {
            second[i].style.visibility = 'visible';
        }
    }
}

for (var i = 0; i <= 9; i++) {
    addFirstDeliverie[i].onchange = Deliverie;
    addFirstDeliverie[i].onblur = Deliverie;
}

function useBonusDeliverie() {

    var firstDeliverie = bonusDeliverie.value;
    var secondDeliverie = bonusDeliverie2.value;


    var totalScore = Number(firstDeliverie) + Number(secondDeliverie);

    if (firstDeliverie == 10) {
        showBonusDeliverie.style.visibility = 'visible';
        showBonusDeliverie2.style.visibility = 'visible';
    }
    else if (totalScore == 10) {
        showBonusDeliverie.style.visibility = 'visible';
    }
    else {
        showBonusDeliverie.style.visibility = 'hidden';
        showBonusDeliverie2.style.visibility = 'hidden';
    }
}
bonusDeliverie.onchange = useBonusDeliverie;
bonusDeliverie.onblur = useBonusDeliverie;

bonusDeliverie2.onchange = useBonusDeliverie;
bonusDeliverie2.onblur = useBonusDeliverie;