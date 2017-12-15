var HorseStat = /** @class */ (function () {
    function HorseStat(id, betCount, winAmount, name, odds) {
        if (id === void 0) { id = 0; }
        if (betCount === void 0) { betCount = 0; }
        if (winAmount === void 0) { winAmount = 0; }
        if (name === void 0) { name = ''; }
        if (odds === void 0) { odds = 0; }
        this.id = id;
        this.betCount = betCount;
        this.winAmount = winAmount;
        this.name = name;
        this.odds = odds;
    }
    return HorseStat;
}());
export { HorseStat };
