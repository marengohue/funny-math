import { expect } from "chai";
import solve from "../src/index";

describe("Funny math", () => {
    it("Should have a solve() function", () => {
        expect(solve).to.be.a('function');
    });

    it("Should pass sample test 1", () => {
        const result = solve(2, [4, 5, 5, 6]);
        expect(result).to.deep.equal([2, 3]);
    });

    it("Should pass sample test 2", () => {
        const result = solve(3, [6, 6, 6, 6, 8, 8, 8, 10]);
        expect(result).to.deep.equal([3, 3, 5]);
    });
});