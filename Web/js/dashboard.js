// On récupère les éléments
const liaison = document.getElementById("liaisonId")
const dateInput = document.getElementById("date")
const rechercher = document.getElementById("rechercher")
const sectionTableauDeBord = document.getElementById("tableauDeBord")

// On initialise les variables
let liaisonSaisi
let dateSaisi

// On récupère l'ID de la liaison, la date et la renvoie à la fonction getRemplissages
rechercher.addEventListener("click", (e) => {
    e.preventDefault()
    liaisonSaisi = liaison.value   // On affecte les valeurs saisi dans des variables
    dateSaisi = dateInput.value

    getRemplissages(liaisonSaisi, dateSaisi)   // Appel de la fonction getRemplissages

    liaison.value = ""    // On vide les champs après que l'utilisateur clique sur rechercher
    dateInput.value = ""
})

/*
    Fonction creerP
    - Prend en paramètres contenu (ce qu'on veut mettre dans le paragraphe), classe (la classe de l'élément (fait au préalable en CSS)), et le parent (dans quel élément on veut le mettre)
    - Créer un élément p en fonction des paramètres saisi (Fonction crée dans le but d'éviter la répétition de code)
*/
function creerP(contenu, classe, parent) {
    const elt = document.createElement('p')
    elt.innerText = contenu
    elt.className = classe
    parent.appendChild(elt)
}

/*
    Fonction getRemplissages
    - Prend en paramètre l'ID de la liaison et la date saisi par l'utilisateur
    - Affiche les taux de remplissages d'une liaison à un jour donné avec ses traversées
*/
async function getRemplissages(liaisonId, date) {
    const requete = await fetch(`https://can.iutrs.unistra.fr/api/liaison/${liaisonId}/remplissage/${date}`)  // On fait la requête
    const remplissages = await requete.json()    // On la met en JSON
    sectionTableauDeBord.innerText = ""         // On vide le tableau

    remplissages.forEach(remplissage => {
        const article = document.createElement("article")
        let tauxPassager = Math.round((remplissage.nbReservationPassagers / remplissage.capacitePassagers) * 100)  // On calcule et l'arrondi (avec Math.round)
        let tauxVoitures = Math.round((remplissage.nbReservationVoitures / remplissage.capaciteVoitures) * 100)   // Idem pour les véhicules

        creerP("Heure : " + remplissage.heure + " | ", "gras", article)
        creerP("Taux de passager : " + tauxPassager + "%", "", article)

        // Si le taux de voitures est inférieur à 50
        if (tauxVoitures < 50) {
            creerP("Taux de voiture : " + tauxVoitures + "%", "vert", article)   // On met la classe vert et on le met dans l'élément article
        } else if (tauxVoitures < 75){
            creerP("Taux de voiture : " + tauxVoitures + "%", "orange", article) // Idem mais classe orange
        } else if (tauxVoitures <= 100){
            creerP("Taux de voiture : " + tauxVoitures + "%", "rouge", article)  // ... rouge
        } else {
            creerP("Taux de voiture : " + tauxVoitures + "%", "jaune-fluo", article)   // jaune fluo
        }
        sectionTableauDeBord.appendChild(article)   // et on met l'article dans la section tableau de bord
    })
}