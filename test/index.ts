import { expect } from "chai";
import solve from "../src/index";
import "lodash.combinations";
import * as _ from "lodash";

function* makePairIterator(inputs: number[]) {
    for (let i = 0; i < inputs.length; i++) {
        for (let j = 0; j < inputs.length; j++) {
            yield [inputs[i], inputs[j]];
        }
    }
}

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
    })

    it("Should pass a random test several times", () => {
        _.times(10, () => {
            const n = _.random(5, 10);
            const expectedOutput = _.times(n, () => _.random(1, 500, false));
            const allPairs = Array.from(makePairIterator(expectedOutput));
            const inputs = _.chain(allPairs).map(_.sum).value().sort();
            const actualResult = solve(n, inputs);
            const sortedResult = _.sortBy(actualResult, _.identity);
            expect(sortedResult).to.deep.equal(expectedOutput);
        });
    });
});