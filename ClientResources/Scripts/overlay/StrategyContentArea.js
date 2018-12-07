define([
    // Dojo
    "dojo/_base/array",
    "dojo/_base/declare",
    "dojo/_base/lang",

    "epi-cms/widget/overlay/ContentArea",
    "alloy/overlay/StrategyBlock"

], function (
        // Dojo
        array,
        declare,
        lang,

        ContentArea,
        StrategyBlock
    ) {

    return declare([ContentArea], {
        // blockClass: [public] Class
        //      Used to inject block overlay class.
        blockClass: StrategyBlock
    });
});