const reservationSaisi = document.getElementById("reservationId")
const rechercher = document.getElementById("rechercher")

const sectionFacture = document.getElementsByClassName("facture")[0]

let numRes = 0

// Si l'utilisateur n'a rien saisi ou numRes vaut 0 alors on cache la section
if (numRes == 0){
    sectionFacture.style.display = 'none'
}


// On récupère l'ID de réservation saisi
rechercher.addEventListener("click", (e) => {
    e.preventDefault()
    numRes = reservationSaisi.value
    getInfos(numRes)
    reservationSaisi.value = ''
})

/*
Fonction getInfos
- Récupère la réservation avec le numéro de réservation en paramètre
- Renvoie les infos récupéré dans les fonctions afficherInfosFacture et afficherTableauFacture
*/
async function getInfos(numReservation) {
    const requete = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${numReservation}`)  // On fait la requête
    const infos = await requete.json()     // On les met en JSON
    sectionFacture.style.display = 'flex'  // On rend visible la section
    
    afficherInfosFacture(infos)
    afficherTableauFacture(infos)
}

if (numRes == 0){
    sectionFacture.style.display = 'none'
}

/*
    Fonction afficherInfosFacture
    - Récupère les infos récupéré par getInfos (en paramètres)
    - Affiche les informations récupéré en paramètres dans la page HTML
*/
function afficherInfosFacture(infos) {
    const dateAujourdhui = new Date()  // Ici on récupère la date du jour
    const villeDate = document.getElementById("villeDate")  // On récupère les éléments HTML...
    const reservationIdFacture = document.getElementById("reservationIdFacture")
    const nom = document.getElementById("nom")
    const traversee = document.getElementById("traversee")
    const date = document.getElementById("date")
    const heureDepart = document.getElementById("heureDepart")
    const bateau = document.getElementById("bateau")


    // Les 2 fonctions suivantes font respectivement afficher le jour actuel et l'heure actuel

    villeDate.innerText = "Illkirch le " + dateAujourdhui.toLocaleDateString() + " à " + dateAujourdhui.toLocaleTimeString()

    // Affichage des informations récupérés.... 
    nom.innerText = infos.nom
    traversee.innerText = infos.portDepart + " - " + infos.portArrivee
    reservationIdFacture.innerText = numRes
    date.innerText = infos.date
    heureDepart.innerText = infos.heure
    bateau.innerText = infos.bateau
}

/*
    Fonction afficherTableauFacture
    - Récupère les infos avec infos en paramètres (juste pour accéder aux passagers et véhicules)
    - Affiche dans le tableau fait dans le fichier HTML facture.html les nombres, tarifs et les totaux des passagers
    - Crée un tableau pour la partie Véhicules et y insère les nombres, tarif et les totaux des véhicules
    - Affiche les sous totaux et le total de la réservation
    */

async function afficherTableauFacture(infos) {
    // PARTIE PASSAGERS
    // Initialisation des variables
    let nbAdulte = 0
    let nbJeune = 0
    let nbEnfant = 0
    let nbBebe = 0
    let nbAnimalCie = 0

    let tarifAdulte = 0
    let tarifJeune = 0
    let tarifEnfant = 0
    let tarifAnimalCie = 0

    // On récupère la liste des passagers et pour chaque catégorie on augmente les compteurs qui correspondent (le compteur de passager par catgéorie)
    for (let i = 1; i <= infos.nbPassagers; i++) {
        let requete = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${infos.id}/passager/${i}`)
        let passager = await requete.json()

        if (passager.libelleCategorie == "Adulte 26 ans et plus") { // Si la catégorie est Adulte 26 ans et plus alors...
            nbAdulte++     // ... On incrémente le nombre d'adulte
            tarifAdulte = passager.price    // On affecte le tarif à la variable 
        }

        if (passager.libelleCategorie == "Jeune 18 à 25 ans inclus") {   // Idem...
            nbJeune++
            tarifJeune = passager.price
        }

        if (passager.libelleCategorie == "Enfant 4 à 17 ans inclus") {
            nbEnfant++
            tarifEnfant = passager.price
        }

        if (passager.libelleCategorie == "Bébé moins de 4 ans") {
            nbBebe++
        }

        if (passager.libelleCategorie == "Animal de compagnie") {
            nbAnimalCie++
            tarifAnimalCie = passager.price
        }
    }

    // On affiche les lignes (voir la description de cette fonction en fin de code)
    afficherLigne("Adulte", nbAdulte, tarifAdulte)
    afficherLigne("Jeune", nbJeune, tarifJeune)
    afficherLigne("Enfant", nbEnfant, tarifEnfant)
    afficherLigne("Bebe", nbBebe, 0)
    afficherLigne("AnimalCie", nbAnimalCie, tarifAnimalCie)

    // On calcule le total des passagers

    let sousTotalPassager = nbAdulte * tarifAdulte + nbJeune * tarifJeune + nbEnfant * tarifEnfant + nbBebe * 0 + nbAnimalCie * tarifAnimalCie
    document.getElementById("sousTotalPassager").innerText = "Total passager : " + sousTotalPassager + " €"  // On l'affiche

    // PARTIE VÉHICULES
    const tableauVehicule = document.getElementById("vehicules")
    tableauVehicule.innerText = ""
    let sousTotalVehicule = 0

    // On crée l'entête du tableau
    const premierLigneTableau = document.createElement("tr")
    const cellule1 = document.createElement("th")
    const cellule2 = document.createElement("th")
    const cellule3 = document.createElement("th")
    const cellule4 = document.createElement("th")

    cellule1.innerText = "Catégorie"
    cellule2.innerText = "Quantité"
    cellule3.innerText = "Prix unitaire"
    cellule4.innerText = "Prix ligne"

    // On met les cellules dans la ligne
    premierLigneTableau.appendChild(cellule1)
    premierLigneTableau.appendChild(cellule2)
    premierLigneTableau.appendChild(cellule3)
    premierLigneTableau.appendChild(cellule4)

    // On met la ligne dans le tableau
    tableauVehicule.appendChild(premierLigneTableau)

    // Pour chaque véhicule
    for (let i = 1; i <= infos.nbVehicules; i++) {
        const requete = await fetch(`https://can.iutrs.unistra.fr/api/reservation/${infos.id}/vehicule/${i}`)
        const vehicule = await requete.json()

        // On crée une ligne avec les celllules
        const ligneTableau = document.createElement("tr")
        const categorie = document.createElement("td")
        const nombreVehiculeTag = document.createElement("td")
        const prixVehiculeTag = document.createElement("td")
        const totalVehiculeTag = document.createElement("td")

        // On affecte les variables
        let nbVehicules = vehicule.quantite
        let prix = vehicule.prix
        let totalVehicule = nbVehicules * prix

        // On affiche les valeurs dans les éléments
        categorie.innerText = vehicule.libelle
        nombreVehiculeTag.innerText = nbVehicules
        prixVehiculeTag.innerText = prix
        totalVehiculeTag.innerText = totalVehicule

        // On fait le total
        sousTotalVehicule += totalVehicule

        // On met les cellules dans la ligne
        ligneTableau.appendChild(categorie)
        ligneTableau.appendChild(nombreVehiculeTag)
        ligneTableau.appendChild(prixVehiculeTag)
        ligneTableau.appendChild(totalVehiculeTag)

        // On met la ligne du tableau dans le tableau
        tableauVehicule.appendChild(ligneTableau)

    }

    // On récupère l'élément sousTotalVehicule et on affiche le total des véhicules
    const sousTotalVehiculeTag = document.getElementById("sousTotalVehicule")
    sousTotalVehiculeTag.innerText = "Total véhicule : " + sousTotalVehicule + " €"

    // On fait le total passagers + véhicules
    let totalReservation = sousTotalPassager + sousTotalVehicule

    // On affiche le total
    const totalTag = document.getElementById("total")
    totalTag.innerText = "Total : " + totalReservation + " €"
}

/*
    Fonction afficherLigne
    - Fonction créé dans le but d'éviter la répétition de code
    - Prends en paramètre id (ex: Adulte...), nb (nombre d'adulte...) et tarif (tarif d'un adulte)
*/
function afficherLigne(id, nb, tarif) {
    document.getElementById("nb" + id).innerText = nb
    document.getElementById("tarif" + id).innerText = tarif
    document.getElementById("total" + id).innerText = nb * tarif
}