import java.util.Arrays;

public class WinterAndMandarins {

	public int getNumber(int[] bags, int K) {

		int minResult = Integer.MAX_VALUE;

		DistanceFromCurrentItem[] temp = new DistanceFromCurrentItem[bags.length];
		for (int i = 0; i < bags.length; i++) {
			int currentItem = bags[i];

			for (int j = 0; j < bags.length; j++) {
				temp[j] = new DistanceFromCurrentItem();
				temp[j].distance = Math.abs(bags[j] - currentItem);
				temp[j].item = bags[j];
			}

			Arrays.sort(temp);

			int distance = Math.abs(temp[K - 1].distance - temp[0].distance);
			if (distance < minResult) {

				minResult = temp[K - 1].item - temp[0].item;
			}

		}

		return Math.abs( minResult );
	}
}

class DistanceFromCurrentItem implements Comparable<DistanceFromCurrentItem> {
	public int item;
	public int distance;
	
	public int compareTo(DistanceFromCurrentItem item) {
		
		return this.distance - item.distance;
	}
	
	
}
