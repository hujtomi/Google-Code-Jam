import org.junit.Assert;
import org.junit.Before;
import org.junit.Test;

public class TypoCoderDiv2Test {

    protected TypoCoderDiv2 solution;

    @Before
    public void setUp() {
        solution = new TypoCoderDiv2();
    }

    @Test(timeout = 2000)
    public void testCase0() {
        int[] rating = new int[]{1000, 1200, 1199};

        int expected = 2;
        int actual = solution.count(rating);

        Assert.assertEquals(expected, actual);
    }

    @Test(timeout = 2000000)
    public void testCase1() {
        int[] rating = new int[]{1500, 2200, 900, 3000};

        int expected = 3;
        int actual = solution.count(rating);

        Assert.assertEquals(expected, actual);
    }

    @Test(timeout = 2000)
    public void testCase2() {
        int[] rating = new int[]{600, 700, 800, 900, 1000, 1100, 1199};

        int expected = 0;
        int actual = solution.count(rating);

        Assert.assertEquals(expected, actual);
    }

    @Test(timeout = 2000)
    public void testCase3() {
        int[] rating = new int[]{0, 4000, 0, 4000, 4000, 0, 0};

        int expected = 4;
        int actual = solution.count(rating);

        Assert.assertEquals(expected, actual);
    }

    @Test(timeout = 2000)
    public void testCase4() {
        int[] rating = new int[]{575, 1090, 3271, 2496, 859, 2708, 3774, 2796, 1616, 2552, 3783, 2435, 1111, 526, 562};

        int expected = 4;
        int actual = solution.count(rating);

        Assert.assertEquals(expected, actual);
    }

}
