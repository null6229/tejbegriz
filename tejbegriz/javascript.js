const apiUrl = "http://localhost/temp/index.php?api";
document.addEventListener("DOMContentLoaded", () => {
    const kolbiCard = document.querySelector("#kolbi");
    async function getAllKolbi(){
        let result = await fetch(apiUrl);
        let kolbi = await result.json();
        showCards(kolbi);
    }
    function showCards(adatok){
        kolbiCard.innerHTML = "";
        let cards = "";
        adatok.forEach(element => {
            cards +=
            `
            <div class="card col-lg-2 col-md-3 col-sm-12 m-3">
            <div class="card-body ">
            <h5 class="card-title"> ${element.x} </h5>
            <p class="card-text">y: ${element.y} </p>
            <p class="card-text">z: ${element.u} </p>
            </div></div>
            `
        });
        kolbiCard.innerHTML = cards;
    }
    getAllKolbi();
})
