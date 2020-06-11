// Your web app's Firebase configuration
var firebaseConfig = {
    apiKey: "AIzaSyBUlITWLKNeZrB5AX4UU1I6qMaoFxkGPWE",
    authDomain: "actionfitfamily1.firebaseapp.com",
    databaseURL: "https://actionfitfamily1.firebaseio.com",
    projectId: "actionfitfamily1",
    storageBucket: "actionfitfamily1.appspot.com",
    messagingSenderId: "224805965884",
    appId: "1:224805965884:web:bf3cabc33538ec3cfe7339",
    measurementId: "G-01JNQZ9XZW"
};

// Initialize Firebase
firebase.initializeApp(firebaseConfig);

function onlogin() {
    firebase.auth().onAuthStateChanged(function (user) {
        if (user) {
            console.log(user.providerData[0].uid)
        } else {
            console.log("로그인 ㄴㄴ")
        }
    });
}
logout();
//로그아웃
function logout() {
    firebase.auth().signOut().then(function () {
    }, function (error) { })
}

//로그인
function login(email, passwd) {
    //signInWithEmailAndPassword 인자로 email이랑 패스워드가 들어가야 함.
    firebase.auth().signInWithEmailAndPassword(email, passwd).then(function (result) {
        unityInstance.SendMessage("Bridge", "changeScene", "Home");
    }).catch(function (error) {

        // Handle Errors here.
        let errorCode = error.code;
        alert(errorCode)
    });
}

//회원가입
function signup(email, passwd) {

    firebase.auth().createUserWithEmailAndPassword(email, passwd).then(function (user) {
        unityInstance.SendMessage("Bridge", "changeScene", "Home");
    }).catch(function (error) {
        let errorCode = error.code;
        let errorMessage = error.message;

        alert(error.message);
    })
}

function newScore(gamename, newscore) {
    var user = firebase.auth().currentUser;
    console.log(user)
    var d = new Date();
    let today = String(d.getFullYear()) + '년' + String(d.getMonth() + 1) + '월' + String(d.getDate()) + '일' 
    today +=  d.getHours() < 10 ? "0"+String(d.getHours())+'시' : String(d.getHours())+'시'
    today +=  d.getMinutes() < 10 ? "0"+String(d.getMinutes())+'분' : String(d.getMinutes())+'분'
    var userid = user.providerData[0].uid
    console.log(userid)
    var postData = {
        createdAt: today,
        score: newscore
    };
    1
    // Get a key for a new Post.
    var newPostKey = firebase.database().ref().child('user').push().key;
    // Write the new post's data simultaneously in the posts list and the user's post list.
    var updates = {};
    updates['/user/' + user.uid + '/' + gamename + '/' + newPostKey] = postData;

    return firebase.database().ref().update(updates);
}
function loadData(gamename) {
    var user = firebase.auth().currentUser;
    if (user) {
        return firebase.database().ref('/user/' + user.uid).orderByChild('score').once('value').then(function (snapshot) {
            snapshot.forEach(function(sdata){
                if(gamename ===sdata.ref.path.pieces_[2]){
                    let key2 = Object.getOwnPropertyNames(sdata.val())
                    console.log(JSON.stringify(sdata.val()).replace(/"/gi,'\''))
                    unityInstance.SendMessage("RankPanel","getKeys",String(key2))
                    unityInstance.SendMessage("RankPanel","getJson",JSON.stringify(sdata.val()).replace(/"/gi,'\''))
                }
            })
        });
    }
}