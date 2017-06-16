 

    var nH, nW, oH, oW;  //variable declaration
function zoomtoggle(iwidesmall, ihighsmall, iwidelarge, ihighlarge, whichimage) {
    oW = whichimage.style.width; oH = whichimage.style.height;
    if ((oW == iwidelarge) || (oH == ihighlarge)) {
        nW = iwidesmall;
        nH = ihighsmall;
    }
    else {
        nW = iwidelarge;
        nH = ihighlarge;
    }
    whichimage.style.width = nW;
    whichimage.style.height = nH;
}

 