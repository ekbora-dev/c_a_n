// On récupère les éléments HTML 
const reservationSaisi = document.getElementById("reservationId")
const rechercher = document.getElementById("rechercher")

const passagerSuivant = document.getElementById("passagerSuivant")
const passagerPrecedent = document.getElementById("passagerPrecedent")

const vehiculeSuivant = document.getElementById("vehiculeSuivant")
const vehiculePrecedent = document.getElementById("vehiculePrecedent")

// Section qui contient tout les cartes 
const sectionPassagerVehicule = document.getElementsByClassName("cartes-embarquement")[0]

// Initialisation des variables
let i = 0
let j = 0
let numRes = 0

rechercher.addEventListener("click", (e) => {
    e.preventDefault()    // Pour éviter le rechargement de la page
    numRes = reservationSaisi.value   // On met la valeur récupéré dans numRes
    getReservation(numRes, 1, 1) // la réservation du numéro indiqué
    i = 1
    j = 1
    sectionPassagerVehicule.style.display = 'flex' // On rend la section visible
    reservationSaisi.value = '' // On vide le champ de recherche
})

// Si le numéro de réservation est 0 (qui n'existe pas dans l'API et aussi le fait que l'utilisateur n'a rien saisi), on affiche rien
if (numRes == 0){
    sectionPassagerVehicule.style.display = 'none'
}

// On va au passager précendent
passagerPrecedent.addEventListener("click", () => {
    i--
    getReservation(numRes, i, j)
})

// On va au passager suivant
passagerSuivant.addEventListener("click", () => {
    i++
    getReservation(numRes, i, j)
})

// On va au véhicule précédent
vehiculePrecedent.addEventListener("click", () => {
    j--
    getReservation(numRes, i, j)
})

// On va au véhicule suivant
vehiculeSuivant.addEventListener("click", () => {
    j++
    getReservation(numRes, i, j)
})

/*
    Fonction getReservation
    - Prends en paramètres le numéro de réservation saisi par l'utilisateur, i pour naviguer entre les passagers, j pour naviguer entre les véhicules
    - Effectue une requête fetch au serveur can.iut.unistra.fr pour récupérer les données json en fonction des paramètres reçus
    - Fonction appelé par les écouteurs d'événement ci-dessus
*/
async function getReservation(numReservation, i, j) {
    const requete = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${numReservation}`)
    const reservation = await requete.json()

    const requete2 = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${numReservation}/passager/${i}`)  // On récupère le passager i
    const passager = await requete2.json()

    const requete3 = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${numReservation}/vehicule/${j}`)  // On récupère le véhicule j
    const vehicule = await requete3.json()


    // Si i atteint le nombre de passager on désactive le bouton suivant
    if (i == reservation.nbPassagers){
        passagerSuivant.disabled = true
    } else {
        passagerSuivant.disabled = false // Sinon on laisse actif
    }


    // Si i = 1 on désactive le bouton précédent
    if (i == 1){
        passagerPrecedent.disabled = true
    } else {
        passagerPrecedent.disabled = false
    }

    // Idem mais pour j (les véhicules)
    if (j == reservation.nbVehicules){
        vehiculeSuivant.disabled = true
    } else {
        vehiculeSuivant.disabled = false
    }

    // Idem mais pour j
    if (j == 1){
        vehiculePrecedent.disabled = true
    } else {
        vehiculePrecedent.disabled = false
    }
    afficherCarte(reservation, passager, vehicule)
}

/*
    Fonction afficherCarte
    - Prend en paramètre les valeurs récupéré dans l'API depuis la fonction getReservation
    - Affiche les valeurs récupérés pour chaque élément
    - Fonction appelé par la fonction getReservation
*/
function afficherCarte(reservation, passager, vehicule) {
    // Récupération des éléments HTML
    const nom = document.getElementById("nom")
    const prenom = document.getElementById("prenom")
    const categorie = document.getElementById("categorie")
    const prix = document.getElementById("prix")

    const nomFamille = document.getElementById("nomFamille")
    const gareDepart = document.getElementById("gareDepart")
    const gareArrivee = document.getElementById("gareArrivee")
    const date = document.getElementById("date")
    const heureDepart = document.getElementById("heureDepart")
    const bateau = document.getElementById("bateau")
    const reservationIdPassager = document.getElementById("reservationIdPassager")

    const libelleVehicule = document.getElementById("libelleVehicule")
    const nombreVehicule = document.getElementById("nombreVehicule")
    const prixVehicule = document.getElementById("prixVehicule")

    const nomFamilleVehicule = document.getElementById("nomFamilleVehicule")
    const gareDepartVehicule = document.getElementById("gareDepartVehicule")
    const gareArriveeVehicule = document.getElementById("gareArriveeVehicule")
    const dateVehicule = document.getElementById("dateVehicule")
    const heureDepartVehicule = document.getElementById("heureDepartVehicule")
    const bateauVehicule = document.getElementById("bateauVehicule")
    const reservationIdVehicule = document.getElementById("reservationIdVehicule")



    // On y affiche les informations qui y correspondent
    nom.innerText = passager.nom
    prenom.innerText = passager.prenom
    categorie.innerText = passager.libelleCategorie
    prix.innerText = passager.price + " €"

    nomFamille.innerText = reservation.nom
    gareDepart.innerText = reservation.portDepart
    gareArrivee.innerText = reservation.portArrivee
    date.innerText = reservation.date
    heureDepart.innerText = reservation.heure
    bateau.innerText = reservation.bateau
    reservationIdPassager.innerText = numRes

    libelleVehicule.innerText = vehicule.libelle
    nombreVehicule.innerText = vehicule.quantite
    prixVehicule.innerText = vehicule.prix

    nomFamilleVehicule.innerText = reservation.nom
    gareDepartVehicule.innerText = reservation.portDepart
    gareArriveeVehicule.innerText = reservation.portArrivee
    dateVehicule.innerText = reservation.date
    heureDepartVehicule.innerText = reservation.heure
    bateauVehicule.innerText = reservation.bateau
    reservationIdVehicule.innerText = numRes
}