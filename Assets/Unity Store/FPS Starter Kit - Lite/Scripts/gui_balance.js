var posX = 0.0;
var posY = 0.0;
var shirina = 0.0;
var vysota = 0.0;
var scrinWidth = 0.0;
var scrinHeight = 0.0;
var scrinBalansWidth = 0.0;
var scrinBalansHeight = 0.0;

function Start ()  {
        posX = GetComponent.<GUITexture>().pixelInset.x;
        posY = GetComponent.<GUITexture>().pixelInset.y;
        shirina = GetComponent.<GUITexture>().pixelInset.width;
        vysota = GetComponent.<GUITexture>().pixelInset.height;
            scrinWidth = Screen.width;
        scrinHeight = Screen.height;
        scrinBalansWidth = 1280 / scrinWidth;
        scrinBalansHeight = 720 / scrinHeight;
        Balans ();
}

function Balans () {
        GetComponent.<GUITexture>().pixelInset.x = posX / scrinBalansWidth;
        GetComponent.<GUITexture>().pixelInset.y = posY / scrinBalansHeight;
        GetComponent.<GUITexture>().pixelInset.width = shirina / scrinBalansWidth;
        GetComponent.<GUITexture>().pixelInset.height = vysota / scrinBalansHeight;
}
