// On récupère les éléments dans le HTML
const liaison = document.getElementById("liaisonId")
const rechercher = document.getElementById("rechercher")
const sectionStats = document.getElementById("stats")

let liaisonSaisi

// On récupère l'ID de liaison saisi
rechercher.addEventListener("click", (e) => {
    e.preventDefault()  // Pour éviter le rechargement de la page
    liaisonSaisi = liaison.value   // On affecte la valeur du champs liaisonId à liaisonSaisi

    getChiffreAffaires(liaisonSaisi)  // On appelle la fonction getChiffreAffaires
    getChiffreAffairesTotal()

    liaison.value = ""
})


/*
    Fonction getChiffreAffaires
    - Prend en paramètre l'ID de la liaison
    - Effectue une requête à l'API, récupère les informations et les affiches dans la page HTML 
*/
async function getChiffreAffaires(liaisonId) {
    sectionStats.innerText = ""  // On vide la section à chaque requête
    const requete = await fetch(`https://can.iutrs.unistra.fr/api/liaison/${liaisonId}/chiffreAffaire`)  // On effectue une requête à l'API
    const chiffreAffaires = await requete.json()  // On la récupère en JSON

    const h2 = document.createElement("h2")   // On crée un élément h2
    h2.innerText = "Chiffres de novembre pour la liaison : " + chiffreAffaires.nom   // On y met du texte
    sectionStats.appendChild(h2)   // On met h2 dans la section

    creerP("Passagers : ", "gras", sectionStats)      // appel de la fonction creerP (création des éléments p)
    creerP("Nombre de passagers : " + chiffreAffaires.passagers.nombre, "", sectionStats)
    creerP("Chiffre d'affaires des passagers : " + Math.round(chiffreAffaires.passagers.chiffreAffaire) + " €", "", sectionStats)
    creerP("Véhicules : ", "gras", sectionStats)
    creerP("Nombre de véhicules : " + chiffreAffaires.vehicules.quantite, "", sectionStats)
    creerP("Chiffre d'affaires des véhicules : " + Math.round(chiffreAffaires.vehicules.chiffreAffaire) + " €", "", sectionStats)

}

async function getChiffreAffairesTotal(){
    // On parcourt tout les liaisons pour faire la somme des chiffres d'affaires de chaque liaison
    let somme = 0
    for (let i = 1; i <= 4; i++){
        const requete = await fetch(`https://can.iutrs.unistra.fr/api/liaison/${i}/chiffreAffaire`)  // On effectue une requête à l'API (i => ID de la liaison)
        const chiffreAffaires = await requete.json()  // On la récupère en JSON
        somme += chiffreAffaires.passagers.chiffreAffaire + chiffreAffaires.vehicules.chiffreAffaire  // On fait la somme
    }
    somme = Math.round(somme)  // On arrondi la somme
    const totalTag = document.createElement("h3")  // On crée un élément 
    totalTag.innerText = "Chifffe d'affaire de novembre : " + somme + "€" // On y affiche la somme
    sectionStats.appendChild(totalTag)    // On l'affiche sur le site
}

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