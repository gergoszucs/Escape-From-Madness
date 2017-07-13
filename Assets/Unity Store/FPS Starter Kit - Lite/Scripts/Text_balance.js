private var pos_X = 0.0;
private var pos_Y = 0.0;
private var textSize = 0;
private var scrinWidth = 0.0;
private var scrinHeight = 0.0;
private var BalansWidth = 0.0;
private var BalansHeight = 0.0;

function Start ()  {
                pos_X = GetComponent.<GUIText>().pixelOffset.x;
                pos_Y = GetComponent.<GUIText>().pixelOffset.y;
                textSize = GetComponent.<GUIText>().fontSize;
                scrinWidth = Screen.width;
                scrinHeight = Screen.height;
                BalansWidth = 1280 / scrinWidth;
                BalansHeight = 720 / scrinHeight;
                GetComponent.<GUIText>().pixelOffset.x = pos_X / BalansWidth;
                GetComponent.<GUIText>().pixelOffset.y = pos_Y / BalansHeight;
                GetComponent.<GUIText>().fontSize = textSize / BalansHeight;
}