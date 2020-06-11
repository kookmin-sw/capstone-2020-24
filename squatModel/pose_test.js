let model, webcam, ctx, labelContainer, maxPredictions;

async function init() {
    const modelURL = "./squatModel/model.json";
    const metadataURL = "./squatModel/metadata.json";

    // load the model and metadata
    // Refer to tmImage.loadFromFiles() in the API to support files from a file picker
    // Note: the pose library adds a tmPose object to your window (window.tmPose)
    model = await tmPose.load(modelURL, metadataURL);
    maxPredictions = model.getTotalClasses();

    // Convenience function to setup a webcam
    const size = 200;
    const flip = true; // whether to flip the webcam
    webcam = new tmPose.Webcam(size, size, flip); // width, height, flip
    await webcam.setup(); // request access to the webcam
    await webcam.play();
    window.requestAnimationFrame(loop);

    // append/get elements to the DOM
    const canvas = document.getElementById("canvas");
    canvas.width = size; canvas.height = size;
    ctx = canvas.getContext("2d");
    labelContainer = document.getElementById("label-container");
    for (let i = 0; i < maxPredictions; i++)
        labelContainer.appendChild(document.createElement("div"));
}

async function loop(timestamp) {
    webcam.update(); // update the webcam frame
    await predict();
    window.requestAnimationFrame(loop);
}

var status = "stand";
var count = 0;

async function predict() {
    // Prediction #1: run input through posenet
    // estimatePose can take in an image, video or canvas html element
    const { pose, posenetOutput } = await model.estimatePose(webcam.canvas);
    // Prediction 2: run input through teachable machine classification model
    const prediction = await model.predict(posenetOutput);

    for (let i = 0; i < maxPredictions; i++) {
        const classPrediction =
            prediction[i].className + ": " + prediction[i].probability.toFixed(2);
        labelContainer.childNodes[i].innerHTML = classPrediction;
    }
    // finally draw the poses
    drawPose(pose);

    // prediction[0] is squat(jump), prediction[1] is stand
    if (currentGame === "Squat") {
        if (prediction[2].probability.toFixed(2) >= 0.9) // stand
        {
            if (status == "jump") {
                count = 1;
                status = "stand";
            }
        }

        if (prediction[1].probability.toFixed(2) >= 0.9) // squat(jump)
            status = "jump";
    }
    else if(currentGame ==="Lunge"){
        if (prediction[2].probability.toFixed(2) >= 0.9) // stand
        {
            if (status == "jump") {
                count = 1;
                status = "stand";
            }
        }

        if (prediction[0].probability.toFixed(2) >= 0.9) // squat(jump)
            status = "jump";
    }else if(currentGame === "JumpingJack"){
        if (prediction[2].probability.toFixed(2) >= 0.9) // stand
        {
            if (status == "jump") {
                count = 1;
                status = "stand";
            }
        }

        if (prediction[3].probability.toFixed(2) >= 0.9) // squat(jump)
            status = "jump";
    }


    if (count == 1) {
        await sendKey("jump");
        count = 0;
    }
}

function drawPose(pose) {
    if (webcam.canvas) {
        ctx.drawImage(webcam.canvas, 0, 0);
        // draw the keypoints and skeleton
        if (pose) {
            const minPartConfidence = 0.5;
            tmPose.drawKeypoints(pose.keypoints, minPartConfidence, ctx);
            tmPose.drawSkeleton(pose.keypoints, minPartConfidence, ctx);
        }
    }
}

async function sendKey(value) {
    unityInstance.SendMessage("Character", "getKey", value);
}