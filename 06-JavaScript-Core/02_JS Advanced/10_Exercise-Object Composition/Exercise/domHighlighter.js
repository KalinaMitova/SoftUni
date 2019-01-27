function select(selector) {
    let element = document.querySelector(selector);

    let deepestNode = element;
    let deepestCounter = 0;
    let bestCounter = 0;

    findDeepestNode(element);
    markNodes(deepestNode);

    function findDeepestNode(el) {
        let childrens = el.children;

        if(childrens.length > 0) {
            for (let i = 0; i < childrens.length; i++) {
                const childElement = childrens[i];
                deepestCounter++;
                findDeepestNode(childElement);
                deepestCounter--;
            }
        } else if(deepestCounter > bestCounter) {
            bestCounter = deepestCounter;
            deepestNode = el;
        }
    }

    function markNodes(element) {
        element.classList.add("highlight");

        if(!element.matches(selector)) {
            markNodes(element.parentNode);
        }
    }
}

select('#content');