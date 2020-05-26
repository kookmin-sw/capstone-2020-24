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

//웹에서 돌린거라서 document가 나오는건데 다큐먼트가 준비되면 바로 실행돼야 하는 함수
$(document).ready(function (s) {
    firebase.auth().onAuthStateChanged(function (user) {
        if(user){}
        else{}
    })
})
//로그아웃
function logout() {
    firebase.auth().signOut().then(function () {
    }, function (error) { })
}
//로그인
function login() {
    //signInWithEmailAndPassword 인자로 email이랑 패스워드가 들어가야 함.
    firebase.auth().signInWithEmailAndPassword(email, passwd).then(function (result) {
    }).catch(function (error) {

        // Handle Errors here.
        let errorCode = error.code;
        alert(errorCode)
    });
}
//회원가입
function signup() {

    firebase.auth().createUserWithEmailAndPassword(email,passwd).then(function (user){

    }).catch(function(error){
        let errorCode = error.code;
        let errorMessage =error.message;

        alert(error.message);
    })
}